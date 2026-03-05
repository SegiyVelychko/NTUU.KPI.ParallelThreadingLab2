using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Services;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Strategies;

internal sealed class HtmlPlinqMapReduceStrategy(HtmlTagParser parser, int degreeOfParallelism) : ITagFrequencyStrategy
{
    private readonly HtmlTagParser _parser = parser;
    private readonly int _degreeOfParallelism = degreeOfParallelism;

    /// <inheritdoc/>
    public string Name => "PLINQ Map-Reduce";

    /// <inheritdoc/>
    public int Degree => _degreeOfParallelism;

    /// <inheritdoc/>
    public Task<Dictionary<string, int>> RunAsync(string[] files)
    {
        var result = files
            .AsParallel()
            .WithDegreeOfParallelism(_degreeOfParallelism)
            .Select(_parser.ParseFile)                                               // MAP
            .Aggregate(                                                               // REDUCE
                seedFactory: () => new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase),
                updateAccumulatorFunc: (local, dict) =>
                {
                    foreach (var (key, value) in dict)
                    {
                        local[key] = local.GetValueOrDefault(key) + value;
                    }

                    return local;
                },
                combineAccumulatorsFunc: (a, b) =>
                {
                    foreach (var (key, value) in b)
                    {
                        a[key] = a.GetValueOrDefault(key) + value;
                    }

                    return a;
                },
                resultSelector: resultData => resultData
            );

        return Task.FromResult(result);
    }
}
