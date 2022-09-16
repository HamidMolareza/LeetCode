using ConsoleApp.Data;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution(ProblemContext db) {
        var query = from person in db.Persons
            group person by person.Email
            into emailGroups
            where emailGroups.Count() > 1
            select new {Email = emailGroups.Key};

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