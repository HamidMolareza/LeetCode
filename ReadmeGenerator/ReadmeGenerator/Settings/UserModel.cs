namespace ReadmeGenerator.Settings;

public class UserModel {
    public List<string> Emails { get; set; } = null!;
    public string? AvatarUrl { get; set; } = null!;
    public string? ProfileUrl { get; set; } = null!;
    public bool Ignore { get; set; }
}