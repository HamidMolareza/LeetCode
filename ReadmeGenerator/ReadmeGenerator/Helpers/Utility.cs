using OnRail;
using OnRail.Extensions.OnFail;
using OnRail.Extensions.OnSuccess;
using OnRail.Extensions.Try;

namespace ReadmeGenerator.Helpers;

public static class Utility {
    public static Task<Result> SaveDataAsync(string path, string data, int numOfTry) =>
        TryExtensions.Try(() =>
                    File.WriteAllTextAsync(path, data),
                numOfTry)
            .OnFailAddMoreDetails(new { path });

    public static Task<Result<string>>
        UseTemplateAsync(this string newValue, string templateFilePath, string oldValue) =>
        TryExtensions.Try(() => File.ReadAllTextAsync(templateFilePath))
            .OnSuccess(template => template.Replace(oldValue, newValue));

    public static string CombineStrings(string separator, params string?[] strings) {
        return string.Join(separator, strings.Where(s => !string.IsNullOrWhiteSpace(s)));
    }
}