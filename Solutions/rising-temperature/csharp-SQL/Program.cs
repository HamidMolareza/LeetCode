using ConsoleApp.Data;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution(ProblemContext db) {
        var query = from w1 in db.Weathers
            from w2 in db.Weathers
            where (w2.RecordDate - w1.RecordDate).TotalDays == 1
                  && w2.Temperature > w1.Temperature
            select new {w2.Id};

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