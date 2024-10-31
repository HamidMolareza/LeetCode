using System.Text;
using OnRail;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;
using ReadmeGenerator.Collector.Models;
using ReadmeGenerator.Settings;

namespace ReadmeGenerator.Generator;

public class GeneratorService(AppSettings settings) {
    public Result<StringBuilder> GenerateReadmeSection(List<Problem> problems, int? limit = null) =>
        TryExtensions.Try(() => limit is null or < 1 ? problems : problems.Take((int)limit).ToList())
            .OnSuccess(targetProblems =>
                GenerateReadme(targetProblems, problems.Count, CountSolutions(problems))
            );

    private static int CountSolutions(IEnumerable<Problem> problems) =>
        problems.Sum(p => p.Solutions.Count);

    private StringBuilder GenerateReadme(List<Problem> problems, int? allProblems = null,
        int? allSolutions = null) {
        var readme = new StringBuilder();

        var numberOfProblemsSolved = allProblems ?? problems.Count;
        readme.AppendLine($"Number of problems solved: **{numberOfProblemsSolved}**\n");

        var numberOfSolutions = allSolutions ?? CountSolutions(problems);
        if (numberOfProblemsSolved != numberOfSolutions)
            readme.AppendLine($"Number of solutions: **{numberOfSolutions}**\n");

        readme.AppendLine("<table>")
            .AppendLine("  <tr>")
            .AppendLine("    <th>Problem</th>")
            .AppendLine("    <th>Description</th>")
            .AppendLine("    <th>Solutions</th>")
            .AppendLine("    <th>Last commit</th>")
            .AppendLine("    <th>Contributors</th>")
            .AppendLine("  </tr>");

        var featuredImageTag = !string.IsNullOrWhiteSpace(settings.FeaturedImage.Url)
            ? $"<img src=\"{settings.FeaturedImage.Url}\" alt=\"*\" width=\"{settings.FeaturedImage.Size}\" height=\"{settings.FeaturedImage.Size}\">"
            : string.Empty;

        foreach (var problem in problems) {
            AppendProblemData(readme, problem, settings.SolutionUrlFormat,
                    settings.ProblemUrlFormat, featuredImageTag)
                .OnFailThrowException();
        }

        readme.AppendLine("</table>");

        return readme;
    }

    private static Result AppendProblemData(StringBuilder source,
        Problem problem, string solutionUrlFormat, string problemUrlFormat, string featuredImageTag) =>
        TryExtensions.Try(() => {
            var baseSolutionUrl = string.Format(solutionUrlFormat, problem.Name);
            var solutionsSection = GenerateSolutionsSection(problem, baseSolutionUrl);
            var readmeUrl = $"<a href=\"{Path.Combine(baseSolutionUrl, "README.md")}\">Readme</a>";
            var lastCommitFormatted = problem.LastSolutionsCommit.ToString("dd-MM-yyyy");

            var url = string.Format(problemUrlFormat, problem.Name);
            var problemLink = $"<a href=\"{url}\">{problem.DisplayName}</a>";
            if (problem.Featured)
                problemLink += $" {featuredImageTag}";

            var contributorDiv = GenerateContributorSection(problem);

            source.AppendLine("  <tr>")
                .AppendLine($"    <td>{problemLink}</td>")
                .AppendLine($"    <td>{readmeUrl}</td>")
                .AppendLine($"    <td>{solutionsSection}</td>")
                .AppendLine($"    <td>{lastCommitFormatted}</td>")
                .AppendLine($"    <td>{contributorDiv}</td>")
                .AppendLine("  </tr>");
        });

    private static string GenerateContributorSection(Problem problem) {
        var contributorLinks = problem.Contributors
            .OrderByDescending(contributor => contributor.NumOfCommits)
            .Select(contributor =>
                $"<a href=\"{contributor.ProfileUrl}\" title=\"{contributor.NumOfCommits} commits\"><img src=\"{contributor.AvatarUrl}\" alt=\"{contributor.Name}\" style=\"border-radius:100%\" width=\"32px\" height=\"32px\"></a>");
        var contributorDiv =
            $"<div style=\"display: flex; flex-direction: row; gap: 2px;\">{string.Join(" ", contributorLinks)}</div>";
        return contributorDiv;
    }

    private static string GenerateSolutionsSection(Problem problem, string baseSolutionUrl) {
        var solutionLinks = problem.Solutions
            .OrderByDescending(solution => solution.LastCommitDate)
            .ThenBy(solution => solution.LanguageName)
            .Select(solution => {
                var solutionUrl = GetSolutionUrl(baseSolutionUrl, solution.LanguageName, solution.SingleFileName);

                return $"<a href=\"{solutionUrl}\">{new FileInfo(solution.LanguageName).Name}</a>";
            });
        var solutionsSection = string.Join(" - ", solutionLinks);
        return solutionsSection;
    }

    private static string GetSolutionUrl(string baseSolutionUrl, string languageName, string? singleFileName) {
        var solutionUrl = Path.Combine(baseSolutionUrl, languageName);
        if (!string.IsNullOrWhiteSpace(singleFileName))
            solutionUrl = Path.Combine(solutionUrl, singleFileName);

        return solutionUrl;
    }
}