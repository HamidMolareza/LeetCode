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

    var risingTemperatures = db.Weathers
        .Where(w1 => db.Weathers
            .Any(w2 => w1.RecordDate.Value == w2.RecordDate.Value.AddDays(1) &&
                       w1.Temperature > w2.Temperature))
        .Select(w1 => new { w1.Id, w1.RecordDate });


    return risingTemperatures;
}