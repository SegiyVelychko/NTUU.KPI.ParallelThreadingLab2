using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Helpers;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Models;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Strategies;

internal sealed class ArraySequentialStrategy : IArrayStatsStrategy
{
    /// <inheritdoc/>
    public string Name => "Sequential";

    /// <inheritdoc/>
    public int Degree => 1;

    /// <inheritdoc/>
    public Task<ArrayStatsDetails> RunAsync(double[] data)
    {
        double min = data[0], max = data[0], sum = 0;
        foreach (double v in data)
        {
            if (v < min) min = v;
            if (v > max) max = v;
            sum += v;
        }

        var sorted = (double[])data.Clone();
        Array.Sort(sorted);

        return Task.FromResult(new ArrayStatsDetails(min, max, StatsHelper.Median(sorted), sum / data.Length));
    }
}
