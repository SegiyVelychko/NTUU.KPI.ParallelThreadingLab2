using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Services;

public sealed class HtmlTagParser
{
    private static readonly Regex TagRegex = new(@"<([a-zA-Z][a-zA-Z0-9]*)", RegexOptions.Compiled);

    public Dictionary<string, int> ParseFile(string path)
    {
        var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (Match match in TagRegex.Matches(File.ReadAllText(path)))
        {
            string tag = match.Groups[1].Value.ToLowerInvariant();
            counts[tag] = counts.GetValueOrDefault(tag) + 1;
        }
        return counts;
    }

    public void MergeInto(ConcurrentDictionary<string, int> global, Dictionary<string, int> local)
    {
        foreach (var (key, value) in local)
            global.AddOrUpdate(key, value, (_, old) => old + value);
    }
}
