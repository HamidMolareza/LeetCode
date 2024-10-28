using System.CommandLine;

namespace ReadmeGenerator;

public static class CommandLine {
    public static Task<int> InvokeAsync(string[] args, AppSettings settings) {
        var readmeTemplatePathOption = new Option<string>(
            ["-t", "--readme-template"],
            () => settings.ReadmeTemplatePath
        );

        var outputOption = new Option<string>(
            ["-o", "--output"],
            () => settings.ReadmeOutputPath,
            "The readme output path");

        var solutionsOption = new Option<string>(
            ["-s", "--solutions"],
            () => settings.SolutionsPath,
            "The solutions directory");

        // Create root command and add options
        var rootCommand = new RootCommand {
            readmeTemplatePathOption,
            outputOption,
            solutionsOption
        };

        // Set handler for root command
        rootCommand.SetHandler((readmeTemplatePath, outputPath, solutionsPath) => {
                settings.ReadmeTemplatePath = readmeTemplatePath;
                settings.ReadmeOutputPath = outputPath;
                settings.SolutionsPath = solutionsPath;
            },
            readmeTemplatePathOption,
            outputOption, solutionsOption
        );

        return rootCommand.InvokeAsync(args);
    }
}