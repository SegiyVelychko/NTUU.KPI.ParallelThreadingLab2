using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Interfaces;
using System.Threading.Tasks.Dataflow;

namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Strategies;

internal sealed class MatrixDataflowWorkerPoolStrategy(int degree) : IMatrixMultiplyStrategy
{
    /// <inheritdoc/>
    public string Name => "Dataflow Worker Pool";

    /// <inheritdoc/>
    public int Degree => degree;

    /// <inheritdoc/>
    public async Task<double[,]> RunAsync(double[,] a, double[,] b)
    {
        int n = a.GetLength(0);
        var c = new double[n, n];

        var block = new ActionBlock<int>(
            i =>
            {
                for (int j = 0; j < n; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < n; k++)
                        sum += a[i, k] * b[k, j];
                    c[i, j] = sum;
                }
            },
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = Degree,
                BoundedCapacity = Degree * 4,
            });

        for (int i = 0; i < n; i++)
            await block.SendAsync(i);

        block.Complete();
        await block.Completion;

        return c;
    }
}
