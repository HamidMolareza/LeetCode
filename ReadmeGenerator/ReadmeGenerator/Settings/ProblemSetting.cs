namespace ReadmeGenerator.Settings;

public class ProblemSetting {
    public string Name { get; set; } = default!;
    public bool Featured { get; set; }
    public List<Contributor> Contributors { get; } = [];

    public class Contributor {
        public string UserName { get; set; } = default!;
        public string AvatarUrl { get; set; } = default!;
        public string ProfileUrl { get; set; } = default!;
    }
}