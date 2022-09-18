using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    // Sample:
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var customers = new Customer[] {
            new() {Name = "Joe",},
            new() {Name = "Henry"},
            new() {Name = "Sam"},
            new() {Name = "Max"}
        };
        db.Customers.AddRange(customers);

        var orders = new Order[] {
            new() {CustomerId = 3},
            new() {CustomerId = 1}
        };
        db.Orders.AddRange(orders);

        await db.SaveChangesAsync();
    }
}