using ConsoleApp.Data;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution(ProblemContext db) {
        var query =
            from person in db.Persons
            join address in db.Addresses
                on person.PersonId equals address.PersonId
                into subAddresses
            from subAddress in subAddresses.DefaultIfEmpty()
            select new {
                person.FirstName,
                person.LastName,
                City = subAddress.City ?? "Null",
                State = subAddress.State ?? "Null"
            };

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