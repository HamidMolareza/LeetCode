using System.Text.RegularExpressions;
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

    public static void SetWorkingDirectory(string path) {
        if (!string.IsNullOrWhiteSpace(path) && path != ".") {
            Directory.SetCurrentDirectory(path);
        }
    }

    public static List<T> RemoveNullItems<T>(this IEnumerable<T?> contributors) {
        return contributors.Where(c => c is not null).ToList()!;
    }

    public static List<string> GetValidFolders(string path, IEnumerable<string> ignorePatterns) {
        if (!Directory.Exists(path))
            throw new DirectoryNotFoundException($"The directory '{path}' does not exist.");

        // Convert ignore patterns to regex patterns
        var regexPatterns = ignorePatterns.Select(ConvertToRegex).ToList();

        // Get all folders in the specified path
        var allFolders = RemoveNullItems(Directory.GetDirectories(path));

        // Filter folders that do not match any ignore patterns
        var matchingFolders = allFolders.Where(folder => {
                var folderName = Path.GetFileName(folder);
                return !regexPatterns.Any(regex => regex.IsMatch(folderName));
            }
        ).ToList();

        return matchingFolders;
    }

    public static Regex ConvertToRegex(string pattern) {
        // Escape special regex characters and convert wildcard patterns
        var regexPattern = Regex.Escape(pattern)
            .Replace(@"\*", ".*") // Convert * to .*
            .Replace(@"\?", "."); // Convert ? to .

        return new Regex($"^{regexPattern}$", RegexOptions.IgnoreCase);
    }

    public static async Task<string> GetDefaultImageAsync(string primaryEmail, IEnumerable<string> aliasEmails,
        string defaultImageUrl) {
        ArgumentNullException.ThrowIfNull(primaryEmail);
        ArgumentNullException.ThrowIfNull(defaultImageUrl);

        // Use the Gravatar image as default user profile
        var avatarUrl = await GravatarHelper.GetGravatarUrlAsync(
            [primaryEmail, ..aliasEmails]);

        // Use default user image if need
        if (string.IsNullOrWhiteSpace(avatarUrl))
            avatarUrl = defaultImageUrl;

        return avatarUrl;
    }
    
    public static string? GetSingleFileName(string path) {
        // Check if the provided path is valid
        if (!Directory.Exists(path)) {
            throw new DirectoryNotFoundException($"The directory '{path}' does not exist.");
        }

        // Get the files in the directory
        var files = Directory.GetFiles(path);

        // Check if there's exactly one file
        return files.Length == 1
            ? Path.GetFileName(files[0]) // Return the single file name
            : null; // Return null if there are no files or more than one
    }
}