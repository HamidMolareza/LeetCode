using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    public DbSet<Person> Persons { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var persons = new Person[] {
            new() {Email = "john@example.com"},
            new() {Email = "bob@example.com"},
            new() {Email = "john@example.com"},
            new() {Email = "john@example.com"},
            new() {Email = "bob@example.com"},
            new() {Email = "bob@example.com"},
            new() {Email = "test@example.com"},
        };
        
        db.Persons.AddRange(persons);
        await db.SaveChangesAsync();
    }
}