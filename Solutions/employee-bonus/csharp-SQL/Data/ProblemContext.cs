using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Bonus> Bonus { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var employees = new Employee[] {
            new() {
                EmployeeId = 1,
                Name = "Joe",
                Supervisor = 3,
                Salary = 1000
            },
            new() {
                EmployeeId = 2,
                Name = "Dan",
                Supervisor = 3,
                Salary = 2000,
                Bonus = new Bonus {
                    BonusValue = 500,
                    EmployeeId = 2
                }
            },
            new() {
                EmployeeId = 3,
                Name = "Brad",
                Supervisor = null,
                Salary = 4000
            },
            new() {
                EmployeeId = 4,
                Name = "Thomas",
                Supervisor = 3,
                Salary = 4000,
                Bonus = new Bonus {
                    BonusValue = 2000,
                    EmployeeId = 4
                }
            },
        };

        db.Employees.AddRange(employees);
        await db.SaveChangesAsync();
    }
}