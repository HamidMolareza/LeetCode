namespace ReadmeGenerator.Collector.Models;

public class Problem {
    public string Name { get; set; }
    public string DisplayName => Name.Replace('-', ' ');
    public DateTime LastSolutionsCommit { get; init; }
    public List<Solution> Solutions { get; init; } = [];
    public List<Contributor> Contributors { get; init; } = [];
}