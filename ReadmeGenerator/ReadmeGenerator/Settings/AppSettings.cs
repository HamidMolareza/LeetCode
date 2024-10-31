using System.Reflection;
using System.Text;

namespace ReadmeGenerator.Settings;

public class AppSettings {
    public string SolutionUrlFormat { get; set; } = default!;
    public string ProblemUrlFormat { get; set; } = default!;
    public string ReadmeTemplatePath { get; set; } = default!;
    public string ReadmeOutputPath { get; set; } = default!;
    public int NumberOfTry { get; set; }
    public List<string> IgnoreFolders { get; init; } = [];

    public string WorkingDirectory { get; set; } = default!;
    public string SolutionsPath { get; set; } = default!;

    public List<UserSetting> Users { get; init; } = [];
    public List<ProblemSetting> Problems { get; init; } = [];
    public string LogLevel { get; set; } = default!;
    public int MainPageLimit { get; set; }
    public string? MainPageFooter { get; set; }
    public string CompleteListTemplatePath { get; set; } = default!;
    public string CompleteListOutputPath { get; set; } = default!;
    public string? DefaultUserProfile { get; set; }
    public string? FeaturedImage { get; set; }


    public override string ToString() {
        var sb = new StringBuilder();
        var type = GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in properties) {
            var value = prop.GetValue(this);
            var formattedValue = FormatValue(value);
            sb.AppendLine($"{prop.Name}: {formattedValue}");
        }

        return sb.ToString();
    }

    private static string FormatValue(object? value) {
        return value switch {
            null => "null",
            string s => $"\"{s}\"",
            IEnumerable<string> list => $"[{string.Join(", ", list.Select(s => $"\"{s}\""))}]",
            IEnumerable<object> objList => $"[{string.Join(", ", objList)}]",
            _ => value.ToString() ?? "null"
        };
    }
}