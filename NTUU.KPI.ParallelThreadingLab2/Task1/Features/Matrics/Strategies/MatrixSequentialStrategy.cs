using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Interfaces;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Strategies;

internal sealed class MatrixSequentialStrategy : IMatrixMultiplyStrategy
{
    /// <inheritdoc/>
    public string Name => "Sequential";

    /// <inheritdoc/>
    public int Degree => 1;

    /// <inheritdoc/>
    public Task<double[,]> RunAsync(double[,] a, double[,] b)
    {
        int n = a.GetLength(0);
        var c = new double[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                double sum = 0;
                for (int k = 0; k < n; k++)
                    sum += a[i, k] * b[k, j];
                c[i, j] = sum;
            }

        return Task.FromResult(c);
    }
}
