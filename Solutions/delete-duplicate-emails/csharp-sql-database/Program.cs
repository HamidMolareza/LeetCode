using ConsoleApp.Data;
using ConsoleApp.Models;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution1(ProblemContext db) {
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
    
    private static IQueryable<object> Solution2(ProblemContext db) {
        var duplicateItems =
            from person1 in db.Persons
            from person2 in db.Persons
            where person1.Email == person2.Email
                  && person1.Id > person2.Id
            select person1;
        
        db.Persons.RemoveRange(duplicateItems);
        db.SaveChanges();
        
        return db.Persons;
    }

    public static async Task Main() {
        await using var db = new ProblemContext();

        await RunTime.Print(() => db.RenewDatabaseAsync(), "Preparing");
        await RunTime.Print(() => ProblemContext.SeedDataAsync(db), "Seeding");

        // var result = RunTime.Print(() => Solution1(db), "Query");
        var result2 = RunTime.Print(() => Solution2(db), "Query2");

        // Console.WriteLine("Result 1:\n");
        // result.Print();
        
        Console.WriteLine("Result 2:\n");
        result2.Print();
    }
}

/*
Sample Result:

Preparing: 612ms
Seeding: 147ms
Query2: 310ms
Result 2:

Id      Email
--------
1       john@example.com
2       bob@example.com
7       test@example.com

*/