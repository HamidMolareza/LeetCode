namespace ReadmeGenerator.Settings;

public class UserSetting {
    public string PrimaryEmail { get; set; } = default!;
    public List<string> AliasEmails { get; init; } = [];
    public string? AvatarUrl { get; set; }
    public string? ProfileUrl { get; set; } = default!;
    public bool Ignore { get; set; }
}