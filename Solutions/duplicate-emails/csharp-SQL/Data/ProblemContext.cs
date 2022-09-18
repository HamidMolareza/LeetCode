using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    public DbSet<Person> Persons { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var persons = new Person[] {
            new() {Email = "a@b.com"},
            new() {Email = "c@d.com"},
            new() {Email = "a@b.com"}
        };

        db.Persons.AddRange(persons);
        await db.SaveChangesAsync();
    }
}