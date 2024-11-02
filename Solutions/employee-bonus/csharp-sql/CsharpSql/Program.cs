using ConsoleSharpTemplate.Data;
using ConsoleSharpTemplate.Helpers;
using Microsoft.Data.SqlClient;

Console.WriteLine("Application Starting...");

try {
    var result = RunTime.Print(Solution, "Query");
    result.Print();
}
catch (InvalidOperationException ex) {
    Console.WriteLine($"Error: {ex.Message}");
}
catch (SqlException ex) {
    Console.WriteLine($"Database error occurred: {ex}");
}


return;
static IQueryable<object> Solution() {
    var db = new AppDbContext();

    var employeeBonuses = db.Employees
    .GroupJoin(
        db.Bonus,
        e => e.EmpId,
        b => b.EmpId,
        (e, b) => new { e.Name, Bonus = b.Select(bn => bn.Bonus).FirstOrDefault() }
    );


    return employeeBonuses;
}