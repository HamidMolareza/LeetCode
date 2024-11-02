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

var result = db.Employees
    .Where(e => e.ManagerId.HasValue)
    .Join(
        db.Employees,
        e => e.ManagerId,
        m => m.EmpId,
        (e, m) => new { Employee = e, Manager = m }
    )
    .Where(em => em.Employee.Salary > em.Manager.Salary)
    .Select(em => new {Employee = em.Employee.Name});

    return result;
}