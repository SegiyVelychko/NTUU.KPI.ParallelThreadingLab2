using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Services;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Strategies;

internal sealed class HtmlSequentialStrategy(HtmlTagParser parser) : ITagFrequencyStrategy
{
    private readonly HtmlTagParser _parser = parser;

    /// <inheritdoc/>
    public string Name => "Sequential";

    /// <inheritdoc/>
    public Task<Dictionary<string, int>> RunAsync(string[] files)
    {
        var result = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (string file in files)
        {
            foreach (var (key, value) in _parser.ParseFile(file))
            {
                result[key] = result.GetValueOrDefault(key) + value;
            }
        }
        return Task.FromResult(result);
    }
}
