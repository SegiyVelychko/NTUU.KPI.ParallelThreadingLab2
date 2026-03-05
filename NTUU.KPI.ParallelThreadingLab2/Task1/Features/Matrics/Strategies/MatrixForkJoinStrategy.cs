using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Interfaces;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Strategies;

internal sealed class MatrixForkJoinStrategy(int degree) : IMatrixMultiplyStrategy
{
    /// <inheritdoc/>
    public string Name => "Fork-Join";

    /// <inheritdoc/>
    public int Degree => degree;

    /// <inheritdoc/>
    public async Task<double[,]> RunAsync(double[,] a, double[,] b)
    {
        int n = a.GetLength(0);
        var c = new double[n, n];
        int chunk = (int)Math.Ceiling(n / (double)Degree);

        var tasks = Enumerable.Range(0, Degree).Select(t => Task.Run(() =>
        {
            int rowStart = t * chunk;
            int rowEnd = Math.Min(rowStart + chunk, n);

            for (int i = rowStart; i < rowEnd; i++)
                for (int j = 0; j < n; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < n; k++)
                        sum += a[i, k] * b[k, j];
                    c[i, j] = sum;
                }
        }));

        await Task.WhenAll(tasks);
        return c;
    }
}
