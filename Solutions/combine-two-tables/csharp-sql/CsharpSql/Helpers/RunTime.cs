using System.Diagnostics;
using System.Text;

namespace ConsoleSharpTemplate.Helpers;

public static class RunTime {
    public static TResult Print<TResult>(Func<TResult> func, string title) {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var result = func();

        stopWatch.Stop();
        var elapsedTime = stopWatch.Elapsed.Format();
        Console.WriteLine($"{title}: {elapsedTime}");

        return result;
    }
    
    public static async Task<TResult> Print<TResult>(Func<Task<TResult>> funcAsync, string title) {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var result = await funcAsync();

        stopWatch.Stop();
        var elapsedTime = stopWatch.Elapsed.Format();
        Console.WriteLine($"{title}: {elapsedTime}");

        return result;
    }

    public static void Print(Action action, string title) {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        action();

        stopWatch.Stop();
        var elapsedTime = stopWatch.Elapsed.Format();
        Console.WriteLine($"{title}: {elapsedTime}");
    }

    private static string Format(this TimeSpan timeSpan) {
        var formattedTime = new StringBuilder();
        if (timeSpan.Hours > 0)
            formattedTime.Append($"{timeSpan.Hours:00}h ");
        if (timeSpan.Minutes > 0)
            formattedTime.Append($"{timeSpan.Minutes:00}m ");
        if (timeSpan.Seconds > 0)
            formattedTime.Append($"{timeSpan.Seconds:00}s ");
        formattedTime.Append($"{timeSpan.Milliseconds}ms");

        return formattedTime.ToString();
    }
}