namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Interfaces;

public interface IMatrixMultiplyStrategy
{
    string Name { get; }
    int Degree { get; }
    Task<double[,]> RunAsync(double[,] a, double[,] b);
}
