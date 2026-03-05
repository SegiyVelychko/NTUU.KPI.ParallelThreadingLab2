using NTUU.KPI.ParallelThreadingLab2.Features.Task1.ArrayStats.Strategies;
using NTUU.KPI.ParallelThreadingLab2.Helpers;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Strategies;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Services;

internal sealed class MatrixMultiplyRunner(IEnumerable<IMatrixMultiplyStrategy> strategies)
{
    private readonly IReadOnlyList<IMatrixMultiplyStrategy> _strategies = [.. strategies];

    public async Task RunAsync()
    {
        Bench.PrintSeparator("Matrix Multiplication N×N");

        const int N = 1_000;
        var (a, b) = GenerateMatrices(N);

        Console.WriteLine($"  Matrix size: {N}×{N}  ({N * N:N0} elements each)");
        Console.WriteLine();

        long baselineMs = 0;

        foreach (var strategy in _strategies)
        {
            string label = strategy.Degree > 1
                ? $"{strategy.Name} (degree={strategy.Degree})"
                : strategy.Name;

            var (_, ms) = await Bench.MeasureAsync(label, () => strategy.RunAsync(a, b));

            if (strategy is MatrixSequentialStrategy)
                baselineMs = ms;
            else
                Bench.PrintSpeedup(baselineMs, ms, strategy.Name, strategy.Degree);
        }
    }

    private static (double[,] A, double[,] B) GenerateMatrices(int n)
    {
        var rng = new Random(42);
        var a = new double[n, n];
        var b = new double[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                a[i, j] = rng.NextDouble() * 100;
                b[i, j] = rng.NextDouble() * 100;
            }

        return (a, b);
    }
}
