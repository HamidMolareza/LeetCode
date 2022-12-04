using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using LeetCode.ErrorDetails;
using LeetCode.Models;
using OnRail;
using OnRail.Extensions.Map;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.SelectResults;
using OnRail.Extensions.Try;

namespace LeetCode {
    public static class Program {
        private static Configs _configs = null!;
        private static Arguments _arguments = null!;

        public static Task Main(string[] args) =>
            InnerMainAsync(args)
                .OnSuccess(() => Console.WriteLine("The operation was completed successfully."))
                .OnFail(result => {
                    result.Detail?.Log();
                    Environment.ExitCode = -1;
                    return result;
                });

        private static Task<Result> InnerMainAsync(IReadOnlyCollection<string> args) =>
            LoadOrGetArguments(args)
                .OnSuccess(() => LoadConfigFileAsync())
                .OnSuccess(GetProblemsAsync)
                .OnSuccess(CreateReadmeAsync)
                .OnSuccess(readme => SaveDataAsync(_arguments.OutputDirectory, readme, _configs.NumOfTry));

        private static Result LoadOrGetArguments(IReadOnlyCollection<string> args) =>
            Arguments.GetProgramDirectory(args.FirstOrDefault())
                .OnSuccess(programDirectory => Arguments.GetOutputDirectory(args.Skip(1).FirstOrDefault())
                    .OnSuccess(outputDirectory => Arguments.GetSolutionsDirectory(args.Skip(2).FirstOrDefault())
                        .OnSuccess(solutionsDirectory => _arguments = new Arguments {
                            ProgramDirectory = programDirectory,
                            OutputDirectory = outputDirectory,
                            SolutionsDirectory = solutionsDirectory
                        })).Map());

        private static Task<Result> LoadConfigFileAsync(int numOfTry = 2) =>
            TryExtensions.Try(() => Path.Combine(_arguments.ProgramDirectory, Configs.ConfigFile))
                .OnSuccess(configFile => File.ReadAllTextAsync(configFile), numOfTry)
                .OnSuccess(configFile => JsonSerializer.Deserialize<Configs>(configFile))
                .OnSuccess(configs => _configs = configs!)
                .Map();

        private static Task<Result<List<Problem>>> GetProblemsAsync() =>
            TryExtensions.Try(() => Directory.GetDirectories(_arguments.SolutionsDirectory), _configs.NumOfTry)
                .OnSuccess(problemDirs => problemDirs.SelectResults(GetProblemAsync))
                .OnSuccess(problems => problems.Where(problem => problem is not null).ToList())!;

        private static Task<Result<Problem?>> GetProblemAsync(string problemDir) =>
            TryExtensions.Try(() => Directory.GetDirectories(problemDir), _configs.NumOfTry)
                .OnSuccessFailWhen(solutionsDir => !solutionsDir.Any(),
                    new ProblemDirectoryIsEmptyError(title: "ProblemDir is not valid",
                        message: "There is no solution in the problem folder."))
                .OnSuccess(GetSolutionsAsync)
                .OnSuccess(solutions => {
                    if (!solutions.Any())
                        return null;

                    return new Problem {
                        Name = new FileInfo(problemDir).Name,
                        Solutions = solutions,
                        LastSolutionsCommit = solutions.GetLastCommitDateTime()
                    };
                }).OnFailAddMoreDetails(new {problemDir});

        private static Task<Result<List<Solution>>> GetSolutionsAsync(string[] languageDirs) =>
            languageDirs.SelectResults(async languageDir =>
                await GetLastCommitDateAsync(languageDir)
                    .OnSuccess(lastCommitDate => new Solution {
                        LanguageName = new FileInfo(languageDir).Name,
                        LastCommitDate = lastCommitDate
                    }).OnFail(e => {
                        Console.WriteLine($"Warning! Error while get last commit of {languageDir}");
                        Console.WriteLine($"More Data: {e.Detail?.GetHeaderOfError()}");
                        Console.WriteLine("We skipped this error.\n");
                        return Result<Solution>.Ok(new Solution());
                    })
            ).OnSuccess(solutions =>
                solutions.Where(solution => !string.IsNullOrEmpty(solution.LanguageName))
                    .ToList());

        private static DateTime GetLastCommitDateTime(this IEnumerable<Solution> solutions) =>
            solutions.Select(solution => solution.LastCommitDate)
                .OrderByDescending(dateTime => dateTime)
                .First();

        private static Task SaveDataAsync(string outputDir, string readme, int numOfTry) =>
            TryExtensions.Try(() =>
                    File.WriteAllTextAsync(Path.Combine(outputDir, _configs.ReadmeFileName), readme), numOfTry)
                .OnFailAddMoreDetails(new {outputDir});

        private static async Task<string> CreateReadmeAsync(IEnumerable<Problem> problems) {
            var problemsList = problems.ToList();
            var result = new StringBuilder();

            var numOfQuestionsSolved = problemsList.Count;
            result.AppendLine($"Number of problems solved: {problemsList.Count}\n");

            var numOfSolutions = problemsList.Sum(problem => problem.Solutions.Count);
            if (numOfQuestionsSolved != numOfSolutions)
                result.AppendLine($"Number of solutions: {numOfSolutions}\n");

            result.AppendLine("| Problem | Description | Solutions | Last commit |")
                .AppendLine("| ----- | ----- | ----- | ----- |");

            problemsList = problemsList.OrderByDescending(problem => problem.LastSolutionsCommit)
                .ThenBy(problem => problem.Name)
                .ToList();

            foreach (var problem in problemsList) {
                Console.Write($"Processing problem {problem.Name}... ");

                result.AppendProblemData(problem)
                    .OnFail(failedResult => failedResult.OnFailThrowException());

                Console.WriteLine("Done");
            }

            var readmeTemplate =
                await File.ReadAllTextAsync(Path.Combine(_arguments.ProgramDirectory, _configs.ReadmeTemplateName));
            return readmeTemplate.Replace("{__REPLACE_FROM_PROGRAM_0__}", result.ToString());
        }

        private static Result AppendProblemData(this StringBuilder source, Problem problem) =>
            TryExtensions.Try(() => string.Format(_configs.LeetCodeProblemFormat, problem.Name))
                .OnSuccess(link => {
                    var solutionsUrl = string.Format(_configs.SolutionUrlFormat, problem.Name);
                    var solutions = problem.Solutions.Select(solution => {
                       var solutionUrl = Path.Combine(solutionsUrl, solution.LanguageName);
                        return $"[{solution.LanguageName}]({solutionUrl})";
                    });
                    var solutionLinks = string.Join(" - ", solutions);

                    var lastCommitFormatted = problem.LastSolutionsCommit.ToString("dd-MM-yyyy");
                    var readmeUrl = Path.Combine(solutionsUrl, "README.md");
                    var line =
                        $"| [{problem.Name.Replace("-", " ")}]({link}) | [Readme]({readmeUrl}) | {solutionLinks} | {lastCommitFormatted} |";
                    source.AppendLine(line);
                });

        private static Task<Result<DateTime>> GetLastCommitDateAsync(string path) =>
            TryExtensions.Try(async () => await (Cli.Wrap("git").WithArguments($"log -1 --date=iso \"{path}\"")
                                                 | Cli.Wrap("grep").WithArguments("^Date"))
                    .ExecuteBufferedAsync())
                .OnSuccess(cmd => {
                    var result = cmd.StandardOutput.Remove(0, 8);
                    return DateTime.Parse(result[..^7]);
                }).OnFailAddMoreDetails(new {path});
    }
}