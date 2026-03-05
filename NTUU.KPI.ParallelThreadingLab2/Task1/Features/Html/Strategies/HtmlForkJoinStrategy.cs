using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Services;
using System.Collections.Concurrent;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Strategies;

internal sealed class HtmlForkJoinStrategy(HtmlTagParser parser, int forks) : ITagFrequencyStrategy
{
    private readonly HtmlTagParser _parser = parser;
    private readonly int _forks = forks;

    /// <inheritdoc/>
    public string Name => $"Fork-Join";

    /// <inheritdoc/>
    public int Degree => _forks;

    /// <inheritdoc/>
    public async Task<Dictionary<string, int>> RunAsync(string[] files)
    {
        var global = new ConcurrentDictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        int chunk = (int)Math.Ceiling(files.Length / (double)_forks);

        var tasks = Enumerable
            .Range(0, _forks)
            .Select(index => Task.Run(() =>
            {
                int start = index * chunk;
                int end = Math.Min(start + chunk, files.Length);

                var local = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                for (int j = start; j < end; j++)
                {
                    foreach (var (key, value) in _parser.ParseFile(files[j]))
                    {
                        local[key] = local.GetValueOrDefault(key) + value;
                    }
                }

                _parser.MergeInto(global, local);
            }));

        await Task.WhenAll(tasks);
        return new Dictionary<string, int>(global, StringComparer.OrdinalIgnoreCase);
    }
}
