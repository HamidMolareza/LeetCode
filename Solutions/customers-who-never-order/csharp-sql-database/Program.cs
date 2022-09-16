using ConsoleApp.Data;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution(ProblemContext db) {
        var query = from customer in db.Customers
            where db.Orders.All(order => order.CustomerId != customer.Id)
            select new {Customers = customer.Name};

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

/*
Sample Output:

Preparing: 961ms
Seeding: 205ms
Query: 7ms
Result:

Customers
---------
Henry
Max

*/