namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Interfaces;

public interface ITagFrequencyStrategy
{
    string Name { get; }
    Task<Dictionary<string, int>> RunAsync(string[] files);
    int Degree => 1;
}
