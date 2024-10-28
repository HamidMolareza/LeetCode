using Microsoft.Extensions.Logging;
using OnRail;
using OnRail.Extensions.Map;
using OnRail.Extensions.OnSuccess;
using OnRail.ResultDetails.Errors;
using ReadmeGenerator.Collector;
using ReadmeGenerator.Collector.Models;
using ReadmeGenerator.Generator;
using ReadmeGenerator.Helpers;

namespace ReadmeGenerator;

public class AppRunner(
    AppSettings settings,
    CollectorService collector,
    GeneratorService generator,
    ILogger<AppRunner> logger) {
    public async Task<Result> RunAsync() {
        Directory.SetCurrentDirectory(settings.WorkingDirectory);
        
        logger.LogDebug("App Settings:\n{settings}", settings.ToString());
        
        // Use the Gravatar image as default user profile
        foreach (var user in settings.Users.Where(user => string.IsNullOrEmpty(user.AvatarUrl))) {
            user.AvatarUrl = await GravatarHelper.GetGravatarUrlAsync(user.Email!);
        }
        
        if (!EnsureInputsAreValid(out var validationResult))
            return validationResult;
        logger.LogDebug("App setting values checked.");

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

        result = Result.Ok();
        return true;
    }
}