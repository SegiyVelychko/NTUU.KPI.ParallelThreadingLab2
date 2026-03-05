using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Models;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Interfaces;

public interface IArrayStatsStrategy
{
    string Name { get; }
    int Degree { get; }
    Task<ArrayStatsDetails> RunAsync(double[] data);
}
