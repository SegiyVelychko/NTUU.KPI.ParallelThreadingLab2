using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Helpers;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Models;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Strategies;

internal sealed class ArrayStatsPlinqMapReduceStrategy(int degree) : IArrayStatsStrategy
{
    /// <inheritdoc/>
    public string Name => "PLINQ Map-Reduce";

    /// <inheritdoc/>
    public int Degree => degree;

    /// <inheritdoc/>
    Task<ArrayStatsDetails> IArrayStatsStrategy.RunAsync(double[] data)
    {
        var (min, max, sum, _) = data
            .AsParallel()
            .WithDegreeOfParallelism(Degree)
            .Aggregate(
                seedFactory: () => (Min: double.MaxValue, Max: double.MinValue, Sum: 0.0, Count: 0),
                updateAccumulatorFunc: (acc, v) => (
                    Math.Min(acc.Min, v),
                    Math.Max(acc.Max, v),
                    acc.Sum + v,
                    acc.Count + 1),
                combineAccumulatorsFunc: (a, b) => (
                    Math.Min(a.Min, b.Min),
                    Math.Max(a.Max, b.Max),
                    a.Sum + b.Sum,
                    a.Count + b.Count),
                resultSelector: r => r);

        var sorted = (double[])data.Clone();
        Array.Sort(sorted);

        return Task.FromResult(new ArrayStatsDetails(min, max, StatsHelper.Median(sorted), sum / data.Length));
    }
}
