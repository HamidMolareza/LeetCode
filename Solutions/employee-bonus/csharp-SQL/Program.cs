using ConsoleApp.Data;

namespace ConsoleApp;

public static class Program {
    private static IQueryable<object> Solution(ProblemContext db) {
        var query =
            from employee in db.Employees
            join bonus in db.Bonus
                on employee.EmployeeId equals bonus.EmployeeId into grouping
            from bonus in grouping.DefaultIfEmpty()
            where bonus == null || bonus.BonusValue < 1000
            select new {
                name = employee.Name,
                bonus = bonus == null ? "null" : bonus.BonusValue.ToString()
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