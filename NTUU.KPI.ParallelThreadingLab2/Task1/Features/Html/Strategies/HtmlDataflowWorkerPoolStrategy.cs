using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Services;
using System.Collections.Concurrent;
using System.Threading.Tasks.Dataflow;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Strategies;

internal sealed class HtmlDataflowWorkerPoolStrategy(HtmlTagParser parser, int workers) : ITagFrequencyStrategy
{
    private readonly HtmlTagParser _parser = parser;
    private readonly int _workers = workers;

    /// <inheritdoc/>
    public string Name => $"Dataflow Worker Pool";

    /// <inheritdoc/>
    public int Degree => _workers;

    /// <inheritdoc/>
    public async Task<Dictionary<string, int>> RunAsync(string[] files)
    {
        var global = new ConcurrentDictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        var block = new ActionBlock<string>(
            file => _parser.MergeInto(global, _parser.ParseFile(file)),
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _workers,
                BoundedCapacity = _workers * 8, // back-pressure buffer
            });

        foreach (string file in files)
            await block.SendAsync(file);

        block.Complete();
        await block.Completion;

        return new Dictionary<string, int>(global, StringComparer.OrdinalIgnoreCase);
    }
}
