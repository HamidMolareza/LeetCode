using Microsoft.Extensions.Logging;
using OnRail;
using OnRail.Extensions.Map;
using OnRail.Extensions.OnSuccess;
using OnRail.ResultDetails.Errors;
using ReadmeGenerator.Collector;
using ReadmeGenerator.Collector.Models;
using ReadmeGenerator.Generator;
using ReadmeGenerator.Helpers;
using ReadmeGenerator.Settings;

namespace ReadmeGenerator;

public class AppRunner(
    AppSettings settings,
    CollectorService collector,
    GeneratorService generator,
    ILogger<AppRunner> logger) {
    public async Task<Result> RunAsync() {
        Utility.SetWorkingDirectory(settings.WorkingDirectory);

        logger.LogDebug("App Settings:\n{settings}", settings.ToString());

        if (!EnsureInputsAreValid(out var validationResult))
            return validationResult;
        logger.LogDebug("App setting values checked.");

        await ConfigUserSettings();

        // Collect problems and solutions
        var problemsResult = await collector.CollectProblemsFromDiskAsync();
        if (!problemsResult.IsSuccess)
            return problemsResult.Map();
        if (problemsResult.Value is null) {
            logger.LogWarning("No problem and solution found!");
            return Result.Ok();
        }

        logger.LogInformation("{Count} problems collected from disk.", problemsResult.Value.Count);

        // Order problems
        var problems = problemsResult.Value
            .OrderByDescending(problem => problem.LastSolutionsCommit)
            .ThenBy(problem => problem.Name)
            .ToList();

        // Generate readme files and save it
        return await GenerateReadmeFiles(problems);
    }

    private async Task ConfigUserSettings() {
        foreach (var user in settings.Users.Where(user => string.IsNullOrWhiteSpace(user.AvatarUrl))) {
            // Use the Gravatar image as default user profile
            user.AvatarUrl = await GravatarHelper.GetGravatarUrlAsync(
                [user.PrimaryEmail, ..user.AliasEmails]);

            // Use default user image if need
            if (string.IsNullOrWhiteSpace(user.AvatarUrl))
                user.AvatarUrl = settings.DefaultUserProfile;
        }
    }

    private async Task<Result> GenerateReadmeFiles(List<Problem> problems) {
        // MainPage Readme
        var mainPageReadmeResult = generator.GenerateReadmeSection(problems, settings.MainPageLimit)
            .OnSuccessOperateWhen(() => !string.IsNullOrWhiteSpace(settings.MainPageFooter),
                section => section.AppendLine($"\n{settings.MainPageFooter}"))
            .OnSuccess(section =>
                section.ToString().UseTemplateAsync(settings.ReadmeTemplatePath, "{__REPLACE_FROM_PROGRAM_0__}"))
            .OnSuccess(readme => Utility.SaveDataAsync(
                settings.ReadmeOutputPath, readme, settings.NumberOfTry));

        //CompleteList Readme
        var completeListReadmeResult = generator.GenerateReadmeSection(problems)
            .OnSuccess(section =>
                section.ToString().UseTemplateAsync(settings.CompleteListTemplatePath, "{__REPLACE_FROM_PROGRAM_0__}"))
            .OnSuccess(readme => Utility.SaveDataAsync(
                settings.CompleteListOutputPath, readme, settings.NumberOfTry));

        // Wait to all tasks done
        Task.WaitAll(mainPageReadmeResult, completeListReadmeResult);

        // Return combined results
        return ResultHelpers.CombineResults(await mainPageReadmeResult, await completeListReadmeResult);
    }

    private bool EnsureInputsAreValid(out Result result) {
        //TODO: Find better way

        if (!File.Exists(settings.ReadmeTemplatePath)) {
            result = Result.Fail(
                new ValidationError(
                    message: $"The readme template path is not valid. ({settings.ReadmeTemplatePath})"));
            return false;
        }

        if (!Directory.Exists(settings.SolutionsPath)) {
            result = Result.Fail(
                new ValidationError(
                    message: $"The solutions directory is not valid. ({settings.SolutionsPath})"));
            return false;
        }

        var usersWithoutPrimaryEmail = settings.Users.Count(user => string.IsNullOrWhiteSpace(user.PrimaryEmail));
        if (usersWithoutPrimaryEmail > 0) {
            result = Result.Fail(new ValidationError(
                message:
                $"{nameof(UserSetting.PrimaryEmail)} is required for users in app settings. {usersWithoutPrimaryEmail} users have not the {nameof(UserSetting.PrimaryEmail)}")
            );
            return false;
        }

        if (string.IsNullOrWhiteSpace(settings.DefaultUserProfile)) {
            result = Result.Fail(new ValidationError(
                message: $"'{nameof(settings.DefaultUserProfile)}' can not be null or empty.")
            );
            return false;
        }

        var invalidProblemSettings =
            settings.Problems.Any(problem => string.IsNullOrWhiteSpace(problem.Name) || problem.Name.Contains(' ')
                || problem.Contributors.Any(c =>
                    string.IsNullOrWhiteSpace(c.UserName)
                    || string.IsNullOrWhiteSpace(c.AvatarUrl)
                    || string.IsNullOrWhiteSpace(c.ProfileUrl))
            );
        if (invalidProblemSettings) {
            result = Result.Fail(new ValidationError(
                message: $"'{nameof(settings.Problems)}' are not valid.")
            );
            return false;
        }

        if (settings.FeaturedImage == null! || string.IsNullOrWhiteSpace(settings.FeaturedImage.Url) ||
            string.IsNullOrWhiteSpace(settings.FeaturedImage.Width) ||
            string.IsNullOrWhiteSpace(settings.FeaturedImage.Height)) {
            result = Result.Fail(new ValidationError(
                message: $"'{nameof(settings.FeaturedImage)}' is required.")
            );
            return false;
        }

        result = Result.Ok();
        return true;
    }
}