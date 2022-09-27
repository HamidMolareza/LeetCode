using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    public DbSet<World> Worlds { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var worlds = new World[] {
            new() {
                Name = "Afghanistan",
                Continent = "Asia",
                Area = 652230,
                Population = 25500100,
                Gdp = 20343000000
            },
            new() {
                Name = "Albania",
                Continent = "Europe",
                Area = 28748,
                Population = 2831741,
                Gdp = 12960000000
            },
            new() {
                Name = "Algeria",
                Continent = "Africa",
                Area = 2381741,
                Population = 37100000,
                Gdp = 188681000000
            },
            new() {
                Name = "Andorra",
                Continent = "Europe",
                Area = 468,
                Population = 78115,
                Gdp = 3712000000
            }
        };

        db.Worlds.AddRange(worlds);
        await db.SaveChangesAsync();
    }
}