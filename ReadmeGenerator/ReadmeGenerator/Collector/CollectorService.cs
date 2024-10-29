using Microsoft.Extensions.Logging;
using OnRail;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.SelectResults;
using OnRail.Extensions.Try;
using ReadmeGenerator.Collector.Models;
using ReadmeGenerator.Helpers;
using ReadmeGenerator.Settings;

namespace ReadmeGenerator.Collector;

public class CollectorService(AppSettings settings, ILogger<CollectorService> logger) {
    public Task<Result<List<Problem>>> CollectProblemsFromDiskAsync() =>
        GitHelper.MakeDirectorySafe(".")
            .OnSuccessTee(result => logger.LogDebug("{result}", result))
            .OnSuccess(() => Utility.GetValidFolders(settings.SolutionsPath, settings.IgnoreFolders))
            .OnSuccessTee(problemDirs => logger.LogDebug("{Count} problems found.", problemDirs.Count))
            .OnSuccess(problemDirs => problemDirs.SelectResults(CollectProblemAsync))
            .OnSuccessTee(problems =>
                logger.LogDebug("{Count} problems and solutions collected from hard.", problems.Count))
            .OnSuccessTee(() => logger.LogDebug("Data joined with cache data."))!;

    private Task<Result<Problem?>> CollectProblemAsync(string problemDir) =>
        TryExtensions.Try(() => Utility.GetValidFolders(problemDir, settings.IgnoreFolders))
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
            .OnSuccess(JoinWithSettingsDataAsync)
            .OnSuccess(Utility.RemoveNullItems)
            .OnSuccess(CombineDuplicateContributors);

    private static List<Contributor> CombineDuplicateContributors(List<Contributor> contributorList) =>
        contributorList.GroupBy(c => c.Email)
            .Select(g => new Contributor(
                    g.First().Name,
                    g.Key,
                    g.Sum(c => c.NumOfCommits)
                ) {
                    AvatarUrl = g.First().AvatarUrl,
                    ProfileUrl = g.First().ProfileUrl
                }
            ).ToList();

    private Task<Result<List<Contributor?>>> JoinWithSettingsDataAsync(List<Contributor> contributors) {
        return contributors.SelectResults(async contributor => {
            var user = FindUser(contributor.Email, settings.Users);
            if (user is null) {
                logger.LogWarning("User config not found for {email}", contributor.Email);

                // Use the Gravatar image as default user profile
                contributor.AvatarUrl =
                    await Utility.GetDefaultImageAsync(contributor.Email, [], settings.DefaultUserProfile!);

                // Cache data in memory
                settings.Users.Add(new UserModel {
                    PrimaryEmail = contributor.Email,
                    AvatarUrl = contributor.AvatarUrl,
                });

                return contributor;
            }

            if (user.Ignore) {
                logger.LogDebug("'{email}' contributor ignored base configs.", contributor.Email);
                return null;
            }

            contributor.Email = user.PrimaryEmail;
            contributor.AvatarUrl = user.AvatarUrl;
            contributor.ProfileUrl = user.ProfileUrl;

            return contributor;
        });
    }

    private static UserModel? FindUser(string contributorEmail, IEnumerable<UserModel> settingsUsers) {
        return settingsUsers.SingleOrDefault(user => {
            return IsEmailEqual(contributorEmail, user.PrimaryEmail)
                   || user.AliasEmails.Any(aliasEmail => IsEmailEqual(aliasEmail, contributorEmail));
        });
    }

    private static bool IsEmailEqual(string email1, string email2) =>
        string.Equals(email1, email2, StringComparison.CurrentCultureIgnoreCase);

    private static Task<Result<List<Solution>>> CollectSolutionsAsync(IEnumerable<string> languageDirs) =>
        languageDirs.SelectResults(languageDir =>
            GitHelper.GetLastCommitDateAsync(languageDir)
                .OnSuccess(lastCommitDate => new Solution {
                    LanguageName = new FileInfo(languageDir).Name,
                    LastCommitDate = lastCommitDate
                })
        );
}