using NTUU.KPI.ParallelThreadingLab2.Helpers;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Strategies;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Services;

internal sealed class ArrayStatsRunner(IEnumerable<IArrayStatsStrategy> strategies)
{
    private readonly IReadOnlyList<IArrayStatsStrategy> _strategies = [.. strategies];

    public async Task RunAsync()
    {
        Bench.PrintSeparator("Array Stats — min / max / median / avg");

        const int Size = 1_000_000;
        var rng = new Random(54);
        var data = Enumerable.Range(0, Size)
                             .Select(_ => rng.NextDouble() * 1_000_000)
                             .ToArray();

        Console.WriteLine($"  Array size: {Size:N0}");
        Console.WriteLine();

        long baselineMs = 0;

        foreach (var strategy in _strategies)
        {
            var (result, ms) = await Bench.MeasureAsync(
                strategy.Degree > 1 ? $"{strategy.Name} (degree={strategy.Degree})" : strategy.Name,
                () => strategy.RunAsync(data));

            if (strategy is ArraySequentialStrategy)
            {
                baselineMs = ms;
                Console.WriteLine($"    min={result.Min:F2}  max={result.Max:F2}  " +
                                  $"median={result.Median:F2}  avg={result.Average:F2}");
            }
            else
            {
                Bench.PrintSpeedup(baselineMs, ms, strategy.Name, strategy.Degree);
            }
        }
    }
}
