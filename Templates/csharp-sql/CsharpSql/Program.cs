using ConsoleSharpTemplate.Helpers;
using Microsoft.Data.SqlClient;

Console.WriteLine("Application Starting...");

// try {
//     var result = RunTime.Print(Solution, "Query");
//     result.Print();
// }
// catch (InvalidOperationException ex) {
//     Console.WriteLine($"Error: {ex.Message}");
// }
// catch (SqlException ex) {
//     Console.WriteLine($"Database error occurred: {ex}");
// }
//
//
// return;
// static IQueryable<object> Solution() {
//     var db = new AppDbContext();
//     var result = from person in db.People
//         join address in db.Addresses
//             on person.PersonId equals address.PersonId into addrGroup
//         from address in addrGroup.DefaultIfEmpty()
//         select new {
//             person.FirstName,
//             person.LastName,
//             City = address.City,
//             State = address.State
//         };
//     return result;
// }