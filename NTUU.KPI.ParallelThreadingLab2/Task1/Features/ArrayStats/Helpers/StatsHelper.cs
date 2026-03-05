namespace NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Helpers;

internal static class StatsHelper
{
    // Merge two sorted spans into a new sorted array — used by Fork-Join median.
    public static double[] MergeSorted(double[] a, double[] b)
    {
        var result = new double[a.Length + b.Length];
        int i = 0, j = 0, k = 0;
        while (i < a.Length && j < b.Length)
            result[k++] = a[i] <= b[j] ? a[i++] : b[j++];
        while (i < a.Length) result[k++] = a[i++];
        while (j < b.Length) result[k++] = b[j++];
        return result;
    }

    public static double Median(double[] sorted) =>
        sorted.Length % 2 == 1
            ? sorted[sorted.Length / 2]
            : (sorted[sorted.Length / 2 - 1] + sorted[sorted.Length / 2]) / 2.0;
}
