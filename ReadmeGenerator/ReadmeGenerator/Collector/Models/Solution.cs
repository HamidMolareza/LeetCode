namespace ReadmeGenerator.Collector.Models;

public class Solution {
    private readonly string _languageName = null!;

    public string LanguageName {
        get => _languageName;
        init {
            if (string.IsNullOrEmpty(value)) {
                throw new ArgumentNullException($"{nameof(LanguageName)} can not be null or empty.");
            }

            _languageName = value;
        }
    }

    public DateTime LastCommitDate { get; init; }

    /// <summary>
    /// If the solution has only single file, this save the file name for ease-access
    /// </summary>
    public string? SingleFileName { get; set; }
}