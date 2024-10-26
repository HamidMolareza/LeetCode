using System;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnRail;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.Try;
using OnRail.ResultDetails;
using ReadmeGenerator.Collector;
using ReadmeGenerator.Configs;
using ReadmeGenerator.Generator;
using ReadmeGenerator.Helpers;
using Serilog;
using Serilog.Events;

namespace ReadmeGenerator;

public static class Program {
    public static Task Main(string[] args) =>
        TryExtensions.Try(() => InnerMain(args))
            .OnFailTee(GlobalErrorLog);

    private static void GlobalErrorLog<T>(Result<T>? result) {
        if (result is null || result.IsSuccess) return;
        GlobalErrorLog(result.Detail);
    }

    private static void GlobalErrorLog(Result? result) {
        if (result is null || result.IsSuccess) return;
        GlobalErrorLog(result.Detail);
    }

    private static void GlobalErrorLog(ResultDetail? detail) {
        //for GitHub action: https://github.com/HamidMolareza/Quera/issues/10
        Environment.ExitCode = -1;

        var sb = new StringBuilder("The operation failed. ");
        if (detail is null)
            sb.AppendLine("That's all we know!");
        else
            sb.AppendLine($"See the below text for more information:\n{detail.ToStr()}");

        Log.Error("{message}", sb.ToString());
    }

    private static Task<int> InnerMain(string[] args) {
        // Setup DI container
        var services = new ServiceCollection();

        var appSettings = services.ConfigAppSettings("appsettings.json");

        ChangeWorkingDirectory(appSettings.WorkingDirectory);

        ConfigSerilog(Utility.ParseLogLevel(appSettings.LogLevel));

        services.AddScoped<CollectorService>();
        services.AddScoped<GeneratorService>();
        services.AddScoped<AppRunner>();

        Log.Debug("Services are registered.");

        var serviceProvider = services.BuildServiceProvider();

        return InvokeCommandLine(args, appSettings, serviceProvider);
    }

    private static void ConfigSerilog(LogEventLevel minimumLevel = LogEventLevel.Debug) {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(minimumLevel)
            .WriteTo.Console(outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
    }

    private static Task<int>
        InvokeCommandLine(string[] args, AppSettings appSettings, IServiceProvider serviceProvider) {
        // Define the options
        var readmeTemplatePathOption = new Option<string>(
            ["-t", "--readme-template"],
            () => appSettings.ReadmeTemplatePath
        );

        var outputOption = new Option<string>(
            ["-o", "--output"],
            () => appSettings.ReadmeOutputPath,
            "The readme output path");

        var solutionsOption = new Option<string>(
            ["-s", "--solutions"],
            () => appSettings.SolutionsPath,
            "The solutions directory");

        // Create root command and add options
        var rootCommand = new RootCommand {
            readmeTemplatePathOption,
            outputOption,
            solutionsOption
        };

        // Set handler for root command
        rootCommand.SetHandler(CommandHandler(serviceProvider),
            readmeTemplatePathOption,
            outputOption, solutionsOption
        );

        return rootCommand.InvokeAsync(args);
    }

    private static Func<string, string, string, Task> CommandHandler(IServiceProvider serviceProvider) {
        return async (readmeTemplatePath, outputPath, solutionsPath) => {
            var settings = await UpdateAppSettings(serviceProvider,
                readmeTemplatePath, outputPath, solutionsPath);
            Log.Debug("App Settings:\n{settings}", settings.ToString());

            // Call other classes/methods with DI
            var runner = serviceProvider.GetService<AppRunner>();
            if (runner is null) throw new Exception("Can not get app runner from DI.");

            var result = await runner.RunAsync();
            GlobalErrorLog(result);
        };
    }

    private static void ChangeWorkingDirectory(string workingDirectory) {
        if (!string.IsNullOrEmpty(workingDirectory) && workingDirectory != ".")
            Directory.SetCurrentDirectory(workingDirectory);
    }

    private static async Task<AppSettings> UpdateAppSettings(IServiceProvider serviceProvider, string readmeTemplatePath,
        string outputPath, string solutionsPath) {
        // Get AppSettings instance from DI
        var settings = serviceProvider.GetService<AppSettings>();
        if (settings is null) throw new Exception("Can not get app settings from DI.");
        
        settings.ReadmeTemplatePath = readmeTemplatePath;
        settings.ReadmeOutputPath = outputPath;
        settings.SolutionsPath = solutionsPath;

        // Use the Gravatar image as default user profile
        foreach (var user in settings.Users.Where(user => string.IsNullOrEmpty(user.AvatarUrl))) {
            user.AvatarUrl = await GravatarHelper.GetGravatarUrlAsync(user.Email!);
        }

        return settings;
    }

    private static AppSettings ConfigAppSettings(this IServiceCollection services, string appSettingsPath) {
        // Build Configuration from the provided appsettings.json path
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appSettingsPath, optional: false, reloadOnChange: true)
            .Build();

        // Bind AppSettings from Configuration
        var appSettings = configuration.Get<AppSettings>() ?? new AppSettings();
        services.AddSingleton(appSettings); // Register AppSettings as singleton
        return appSettings;
    }
}