using ConsoleApp.Data;

namespace ConsoleApp;

public static class Program {
    private static object Solution(ProblemContext db) {
        var requests = db.FriendRequests
            .GroupBy(item => new {item.SenderId, item.SendToId})
            .Count();

        var accepted = db.RequestAccepteds
            .Select(request => new {request.RequesterId, request.AccepterId})
            .Distinct()
            .Count();

        var acceptedRate = (accepted * 1.0 / requests).ToString("n2");
        return new {acceptedRate};
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