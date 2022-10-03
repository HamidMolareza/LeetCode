using ConsoleApp.Data;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution(ProblemContext db) {
        var query = from course in db.Courses
            group course by course.Class
            into g
            where g.Count() >= 5
            select new {Class = g.Key};

        // var query =  db.Courses
        //     .GroupBy(course => course.Class)
        //     .Where(g => g.Count() >= 5)
        //     .Select(g => g.Key);

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