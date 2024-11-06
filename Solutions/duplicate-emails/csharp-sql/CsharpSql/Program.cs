﻿using ConsoleSharpTemplate.Data;
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

    var duplicateEmails = db.People
    .GroupBy(p => p.Email)
    .Where(g => g.Count() > 1)
    .Select(g => new {Email = g.Key});

    return duplicateEmails;
}