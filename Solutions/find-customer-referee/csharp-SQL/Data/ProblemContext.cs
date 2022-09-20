using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    public DbSet<Customer> Customers { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var customers = new Customer[] {
            new() {
                Name = "Will",
                RefereeId = null
            },
            new() {
                Name = "Jane",
                RefereeId = null
            },
            new() {
                Name = "Alex",
                RefereeId = 2
            },
            new() {
                Name = "Bill",
                RefereeId = null
            },
            new() {
                Name = "Zack",
                RefereeId = 1
            },
            new() {
                Name = "Mark",
                RefereeId = 2
            }
        };

        db.Customers.AddRange(customers);
        await db.SaveChangesAsync();
    }
}