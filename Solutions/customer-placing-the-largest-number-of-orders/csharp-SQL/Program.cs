using ConsoleApp.Data;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution(ProblemContext db) {
        var orderBaseNumberOfOrders = from order in db.Orders
            group order by order.CustomerNumber
            into g
            orderby g.Count() descending
            select new {customer_number = g.Key, count = g.Count()};

        var largestOrderCount = orderBaseNumberOfOrders.FirstOrDefault()?.count;
        var largestOrders = from order in orderBaseNumberOfOrders
            where order.count == largestOrderCount
            select new {order.customer_number};

        return largestOrders;
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