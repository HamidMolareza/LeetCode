using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data; 

public partial class ProblemContext {
    public DbSet<Employee> Employees { get; set; } = null!;
    
    public static async Task SeedDataAsync(ProblemContext db) {
        var employees = new Employee[] {
            new() {
                Name = "Joe",
                Salary = 70000,
                ManagerId = 3
            },
            new() {
                Name = "Henry",
                Salary = 80000,
                ManagerId = 4
            },
            new() {
                Name = "Sam",
                Salary = 60000
            },
            new() {
                Name = "Max",
                Salary = 90000
            }
        };

        db.Employees.AddRange(employees);
        await db.SaveChangesAsync();
    }
}