using System.Diagnostics;

namespace NTUU.KPI.ParallelThreadingLab2.Helpers;

/// <summary>
/// Utility to measure elapsed time and print a formatted result row.
/// </summary>
public static class Bench
{
    public static (T Result, long Ms) Measure<T>(string label, Func<T> action)
    {
        var sw = Stopwatch.StartNew();
        var result = action();
        sw.Stop();
        Console.WriteLine($"  [{label,-42}]  {sw.ElapsedMilliseconds,7} ms");
        return (result, sw.ElapsedMilliseconds);
    }

    public static long Measure(string label, Action action)
    {
        var sw = Stopwatch.StartNew();
        action();
        sw.Stop();
        Console.WriteLine($"  [{label,-42}]  {sw.ElapsedMilliseconds,7} ms");
        return sw.ElapsedMilliseconds;
    }

    public static async Task<(T Result, long Ms)> MeasureAsync<T>(string label, Func<Task<T>> action)
    {
        var sw = Stopwatch.StartNew();
        var result = await action();
        sw.Stop();
        Console.WriteLine($"  [{label,-124}]  {sw.ElapsedMilliseconds,7} ms");
        return (result, sw.ElapsedMilliseconds);
    }

    public static async Task<long> MeasureAsync(string label, Func<Task> action)
    {
        var sw = Stopwatch.StartNew();
        await action();
        sw.Stop();
        Console.WriteLine($"  [{label,-42}]  {sw.ElapsedMilliseconds,7} ms");
        return sw.ElapsedMilliseconds;
    }

    public static void PrintSpeedup(long baselineMs, long parallelMs, string strategyName, int degree)
    {
        double speedup = baselineMs > 0 ? (double)baselineMs / parallelMs : 0;
        Console.WriteLine($"  [{strategyName} degree={degree}]: {speedup:F2}x speedup");
    }

    public static void PrintSeparator(string title = "")
    {
        Console.WriteLine();
        if (!string.IsNullOrEmpty(title))
            Console.WriteLine($"  ── {title} ──");
    }
}
