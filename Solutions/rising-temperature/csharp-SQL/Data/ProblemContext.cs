using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    public DbSet<Weather> Weathers { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var weathers = new Weather[] {
            new() {
                RecordDate = new DateTime(2015, 01, 01),
                Temperature = 10
            },
            new() {
                RecordDate = new DateTime(2015, 01, 02),
                Temperature = 25
            },
            new() {
                RecordDate = new DateTime(2015, 01, 03),
                Temperature = 20
            },
            new() {
                RecordDate = new DateTime(2015, 01, 04),
                Temperature = 30
            }
        };

        db.Weathers.AddRange(weathers);
        await db.SaveChangesAsync();
    }
}