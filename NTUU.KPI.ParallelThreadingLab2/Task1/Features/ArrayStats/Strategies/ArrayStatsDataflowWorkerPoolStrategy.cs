using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Helpers;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Models;
using System.Collections.Concurrent;
using System.Threading.Tasks.Dataflow;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Strategies;

internal sealed class ArrayStatsDataflowWorkerPoolStrategy(int degree) : IArrayStatsStrategy
{
    /// <inheritdoc/>
    public string Name => "Dataflow Worker Pool";

    /// <inheritdoc/>
    public int Degree => degree;

    /// <inheritdoc/>
    public async Task<ArrayStatsDetails> RunAsync(double[] data)
    {
        int chunk = (int)Math.Ceiling(data.Length / (double)Degree);
        var bag = new ConcurrentBag<(double Min, double Max, double Sum, double[] Sorted)>();

        var block = new ActionBlock<int>(
            i =>
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
                bag.Add((min, max, sum, slice));
            },
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = Degree,
                BoundedCapacity = Degree * 2,
            });

        for (int i = 0; i < Degree; i++)
            await block.SendAsync(i);

        block.Complete();
        await block.Completion;

        // Reduce
        double gMin = double.MaxValue, gMax = double.MinValue, gSum = 0;
        double[] sorted = [];
        foreach (var (cMin, cMax, cSum, cSorted) in bag)
        {
            if (cMin < gMin) gMin = cMin;
            if (cMax > gMax) gMax = cMax;
            gSum += cSum;
            sorted = sorted.Length == 0 ? cSorted : StatsHelper.MergeSorted(sorted, cSorted);
        }

        return new ArrayStatsDetails(gMin, gMax, StatsHelper.Median(sorted), gSum / data.Length);
    }
}