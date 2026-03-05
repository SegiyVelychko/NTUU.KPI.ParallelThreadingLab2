using NTUU.KPI.ParallelThreadingLab2.Helpers;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Strategies;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Services;

internal sealed class HtmlTagFrequency(HtmlDocumentGenerator generator, IReadOnlyList<ITagFrequencyStrategy> strategies)
{
    private readonly HtmlDocumentGenerator _generator = generator;
    private readonly IEnumerable<ITagFrequencyStrategy> _strategies = [.. strategies];

    /// <inheritdoc/>
    public async Task RunAsync()
    {
        Bench.PrintSeparator("HTML Tag Frequency");

        string dataDir = Path.Combine(AppContext.BaseDirectory, "html_docs");
        _generator.Generate(dataDir, 1000);

        string[] files = Directory.GetFiles(dataDir, "*.html");
        Console.WriteLine($"  Documents: {files.Length}");
        Console.WriteLine();

        long baselineMs = 0;

        foreach (var strategy in _strategies)
        {
            var (result, ms) = await Bench.MeasureAsync(strategy.Name, () => strategy.RunAsync(files));

            if (strategy is HtmlSequentialStrategy)
                baselineMs = ms;
            else
                Bench.PrintSpeedup(baselineMs, ms, strategy.Name, strategy.Degree);
        }
    }
}
