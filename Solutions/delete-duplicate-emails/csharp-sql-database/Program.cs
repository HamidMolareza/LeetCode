using ConsoleApp.Data;
using ConsoleApp.Models;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution(ProblemContext db) {
        var duplicateItems = db.Persons
            .GroupBy(person => person.Email)
            .Select(grouping => grouping.Skip(1))
            .ToList()
            .Aggregate(new List<Person>(), (result, persons) => 
                result.Concat(persons).ToList());
        
        db.Persons.RemoveRange(duplicateItems);
        db.SaveChanges();
        
        return db.Persons;
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