using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public partial class ProblemContext {
    public DbSet<Order> Orders { get; set; } = null!;

    public static async Task SeedDataAsync(ProblemContext db) {
        var orders = new Order[] {
            new() {CustomerNumber = 1},
            new() {CustomerNumber = 2},
            new() {CustomerNumber = 3},
            new() {CustomerNumber = 3},
            new() {CustomerNumber = 1},
        };

        db.Orders.AddRange(orders);
        await db.SaveChangesAsync();
    }
}