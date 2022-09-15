using Newtonsoft.Json.Linq;

namespace ConsoleApp.Data;

public static class AppSettings {
    public const string AppSettingsPath = @"AppSettings.json";

    private static bool _isDataLoaded;
    private static string? _connectionString;
    private static string? _databaseName;

    public static string ConnectionString {
        get {
            if (!_isDataLoaded)
                LoadAppSettings();
            return _connectionString!;
        }
        set => _connectionString = value;
    }

    public static string DatabaseType {
        get {
            if (!_isDataLoaded)
                LoadAppSettings();
            return _databaseName!;
        }
        set => _databaseName = value;
    }

    private static void LoadAppSettings() {
        if (!File.Exists(AppSettingsPath))
            throw new FileNotFoundException($"Can not find AppSettings in {AppSettingsPath}");

        var text = File.ReadAllText(AppSettingsPath);
        var appSettings = JObject.Parse(text);

        ConnectionString = GetObject<string>(appSettings, nameof(ConnectionString));
        DatabaseType = GetObject<string>(appSettings, nameof(DatabaseType));

        _isDataLoaded = true;
    }

    private static T GetObject<T>(JObject appSettings, string propName) {
        try {
            return appSettings[propName]!.ToObject<T>()
                   ?? throw new InvalidOperationException();
        }
        catch (Exception) {
            throw new ArgumentException(
                $"Can not find {propName} to {AppSettingsPath}");
        }
    }
}