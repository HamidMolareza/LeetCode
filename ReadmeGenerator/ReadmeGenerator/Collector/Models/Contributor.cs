namespace ReadmeGenerator.Collector.Models;

public class Contributor {
    public Contributor(string name) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        Name = name;
    }

    public string Name { get; set; }
    public string? Email { get; set; }
    public int? NumOfCommits { get; set; }
    public string? AvatarUrl { get; set; }
    public string? ProfileUrl { get; set; }
}