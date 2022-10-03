using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    public DbSet<Course> Courses { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var courses = new Course[] {
            new() {
                Student = "A",
                Class = "Math"
            },
            new() {
                Student = "B",
                Class = "English"
            },
            new() {
                Student = "C",
                Class = "Math"
            },
            new() {
                Student = "D",
                Class = "Biology"
            },
            new() {
                Student = "E",
                Class = "Math"
            },
            new() {
                Student = "F",
                Class = "Computer"
            },
            new() {
                Student = "G",
                Class = "Math"
            },
            new() {
                Student = "H",
                Class = "Math"
            },
            new() {
                Student = "I",
                Class = "Math"
            },
        };

        db.Courses.AddRange(courses);
        await db.SaveChangesAsync();
    }
}