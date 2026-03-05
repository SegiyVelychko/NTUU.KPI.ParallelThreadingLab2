using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Helpers;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Models;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Strategies;

internal sealed class ArrayStatsForkJoinStrategy(int degree) : IArrayStatsStrategy
{
    /// <inheritdoc/>
    public string Name => "Fork-Join";

    /// <inheritdoc/>
    public int Degree => degree;

    /// <inheritdoc/>
    public async Task<ArrayStatsDetails> RunAsync(double[] data)
    {
        int chunk = (int)Math.Ceiling(data.Length / (double)Degree);
        var chunkStats = new (double Min, double Max, double Sum, double[] Sorted)[Degree];

        var tasks = Enumerable.Range(0, Degree).Select(i => Task.Run(() =>
        {
            int start = i * chunk;
            int end = Math.Min(start + chunk, data.Length);

            double min = data[start], max = data[start], sum = 0;
            var slice = new double[end - start];
            for (int j = start; j < end; j++)
            {
                double v = data[j];
                slice[j - start] = v;
                if (v < min) min = v;
                if (v > max) max = v;
                sum += v;
            }
            Array.Sort(slice);
            chunkStats[i] = (min, max, sum, slice);
        }));

        await Task.WhenAll(tasks);

        // Reduce min/max/sum
        double gMin = chunkStats[0].Min, gMax = chunkStats[0].Max, gSum = 0;
        foreach (var (cMin, cMax, cSum, _) in chunkStats)
        {
            if (cMin < gMin) gMin = cMin;
            if (cMax > gMax) gMax = cMax;
            gSum += cSum;
        }

        // Merge sorted chunks pairwise
        double[] sorted = chunkStats[0].Sorted;
        for (int i = 1; i < Degree; i++)
            sorted = StatsHelper.MergeSorted(sorted, chunkStats[i].Sorted);

        return new ArrayStatsDetails(gMin, gMax, StatsHelper.Median(sorted), gSum / data.Length);
    }
}
