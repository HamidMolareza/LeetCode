using ConsoleApp.Data;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution(ProblemContext db) {
        var query = db.Customers.Where(customer => customer.RefereeId != 2)
            .Select(customer => new {customer.Name});
        return query;
    }

    public static async Task Main() {
        await using var db = new ProblemContext();

        await RunTime.Print(() => db.RenewDatabaseAsync(), "Preparing");
        await RunTime.Print(() => ProblemContext.SeedDataAsync(db), "Seeding");

        var result = RunTime.Print(() => Solution(db), "Query");

        Console.WriteLine("Result:\n");
        result.Print();
    }
}