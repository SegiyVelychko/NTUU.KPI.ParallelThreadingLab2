using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Interfaces;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Strategies;

internal sealed class MatrixPlinqMapReduceStrategy(int degree) : IMatrixMultiplyStrategy
{
    /// <inheritdoc/>
    public string Name => "PLINQ Map-Reduce";

    /// <inheritdoc/>
    public int Degree => degree;

    /// <inheritdoc/>
    public Task<double[,]> RunAsync(double[,] a, double[,] b)
    {
        int n = a.GetLength(0);
        var c = new double[n, n];

        var rows = Enumerable.Range(0, n)
            .AsParallel()
            .AsOrdered()
            .WithDegreeOfParallelism(Degree)
            .Select(i =>                                                             // MAP
            {
                var row = new double[n];
                for (int j = 0; j < n; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < n; k++)
                        sum += a[i, k] * b[k, j];
                    row[j] = sum;
                }
                return (i, row);
            });

        foreach (var (i, row) in rows)                                              // REDUCE
            for (int j = 0; j < n; j++)
                c[i, j] = row[j];

        return Task.FromResult(c);
    }
}
