using Microsoft.Extensions.Logging;
using OnRail;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.SelectResults;
using OnRail.Extensions.Try;
using ReadmeGenerator.Collector.Models;
using ReadmeGenerator.Helpers;

namespace ReadmeGenerator.Collector;

public class CollectorService(AppSettings settings, ILogger<CollectorService> logger) {
    public Task<Result<List<Problem>>> CollectProblemsFromDiskAsync() =>
        GitHelper.MakeDirectorySafe(".")
            .OnSuccessTee(result => logger.LogDebug("{result}", result))
            .OnSuccess(() => Directory.GetDirectories(settings.SolutionsPath))
            .OnSuccessTee(problemDirs => logger.LogDebug("{Count} problems found.", problemDirs.Length))
            .OnSuccess(problemDirs => problemDirs.SelectResults(CollectProblemAsync))
            .OnSuccessTee(problems => logger.LogDebug("{Count} problems and solutions collected from hard.", problems.Count))
            .OnSuccessTee(() => logger.LogDebug("Data joined with cache data."))!;

    private Task<Result<Problem?>> CollectProblemAsync(string problemDir) =>
        GetValidSolutionDirs(problemDir, settings.IgnoreSolutions, settings.NumberOfTry)
            .OnSuccess(CollectSolutionsAsync)
            .OnSuccess(async solutions => {
                if (solutions.Count == 0) {
                    logger.LogDebug("'{problemDir}' has not any valid solutions so skip it.", problemDir);
                    return Result<Problem?>.Ok(null);
                }

                var problemName = new FileInfo(problemDir).Name;

                return await GitHelper.GetLastCommitDateAsync(problemDir)
                    .OnSuccess(lastCommitDate => CollectContributorsAsync(problemDir)
                        .OnSuccess(contributors =>
                            Result<Problem?>.Ok(CreateProblemObj(problemName, lastCommitDate, solutions, contributors))
                        ));
            }).OnFailAddMoreDetails(new { problemDir });

    private static Problem CreateProblemObj(string problemName, DateTime lastCommitDate, List<Solution> solutions,
        List<Contributor> contributors) {
        return new Problem {
            Name = problemName,
            LastSolutionsCommit = lastCommitDate,
            Solutions = solutions,
            Contributors = contributors
        };
    }

    private Task<Result<List<Contributor>>>
        CollectContributorsAsync(string problemDir) =>
        GitHelper.GetContributorsAsync(problemDir)
            .OnSuccess(JoinWithSettingsData)
            .OnSuccess(contributors =>
                contributors.Where(c => c is not null).ToList()
            )!;

    private Task<Result<List<Contributor?>>> JoinWithSettingsData(List<Contributor> contributors) {
        return contributors.SelectResults(async contributor => {
            var user = settings.Users.SingleOrDefault(user =>
                string.Equals(user.Email, contributor.Email, StringComparison.CurrentCultureIgnoreCase));
            if (user is null) {
                logger.LogDebug("User config not found for {email}", contributor.Email);

                // Use the Gravatar image as default user profile
                contributor.AvatarUrl = await GravatarHelper.GetGravatarUrlAsync(contributor.Email);
                logger.LogDebug("The gravatar url was set for this user profile: {url}", contributor.AvatarUrl);

                return contributor;
            }

            if (user.Ignore) {
                logger.LogDebug("'{email}' contributor ignored base configs.", contributor.Email);
                return null;
            }

            contributor.AvatarUrl = user.AvatarUrl;
            contributor.ProfileUrl = user.ProfileUrl;

            return contributor;
        });
    }

    private static Result<IEnumerable<string>> GetValidSolutionDirs(string problemDir,
        IEnumerable<string> ignoreSolutions, int numOfTry) =>
        TryExtensions.Try(() => Directory.GetDirectories(problemDir), numOfTry)
            .OnSuccess(solutions =>
                solutions.Where(solution => IsSolutionNameValid(new FileInfo(solution).Name, ignoreSolutions)));

    private static bool IsSolutionNameValid(string solutionName, IEnumerable<string> ignoreSolutions)
        => !solutionName.StartsWith('.') && ignoreSolutions.All(ignoreSolution => ignoreSolution != solutionName);

    private static Task<Result<List<Solution>>> CollectSolutionsAsync(IEnumerable<string> languageDirs) =>
        languageDirs.SelectResults(languageDir =>
            GitHelper.GetLastCommitDateAsync(languageDir)
                .OnSuccess(lastCommitDate => new Solution {
                    LanguageName = new FileInfo(languageDir).Name,
                    LastCommitDate = lastCommitDate
                })
        );
}