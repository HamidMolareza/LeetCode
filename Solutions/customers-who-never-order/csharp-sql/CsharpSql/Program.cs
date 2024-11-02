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

    var customersWithoutOrders = db.Customers
    .Where(c => !db.Orders.Any(o => o.CustomerId == c.Id))
    .Select(c => new {Customers = c.Name});


    return customersWithoutOrders;
}