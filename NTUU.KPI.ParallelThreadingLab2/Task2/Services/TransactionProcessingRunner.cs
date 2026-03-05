using NTUU.KPI.ParallelThreadingLab2.Helpers;
using NTUU.KPI.ParallelThreadingLab2.Task2.Helpers;
using NTUU.KPI.ParallelThreadingLab2.Task2.Models;

namespace NTUU.KPI.ParallelThreadingLab2.Task2.Services;

public sealed class TransactionProcessingRunner(int count = 400_000, int[]? degrees = null)
{
    private readonly int _count = count;
    private readonly int[] _degrees = degrees ?? [2, 4, 8, Environment.ProcessorCount];

    public async Task RunAsync()
    {
        Bench.PrintSeparator("Financial Transaction Processing");

        Console.Write($"  Generating {_count:N0} transactions with Bogus... ");
        var transactions = TransactionGenerator.Generate(_count);
        Console.WriteLine("done.");
        Console.WriteLine($"  Cashback threshold: UserId > {TransactionProcessor.CashbackThreshold} → 20%");
        Console.WriteLine();

        // ── Sequential baseline ────────────────────────────────────────────
        var (seqResult, seqMs) = await Bench.MeasureAsync(
            "Sequential",
            () => Task.FromResult(RunSequential(transactions)));
        PrintResult(seqResult);

        // ── Pipeline ───────────────────────────────────────────────────────
        Console.WriteLine();
        Console.WriteLine("  ▸ Pipeline (TPL Dataflow: Convert + Cashback → Aggregate)");
        foreach (int degree in _degrees.Distinct())
        {
            var (result, ms) = await Bench.MeasureAsync(
                $"Pipeline (degree={degree})",
                () => new PipelinePattern(degree).RunAsync(transactions));
            PrintResult(result);
            Bench.PrintSpeedup(seqMs, ms, "Pipeline", degree);
        }

        // ── Producer-Consumer ──────────────────────────────────────────────
        Console.WriteLine();
        Console.WriteLine("  ▸ Producer-Consumer (System.Threading.Channels)");
        foreach (int degree in _degrees.Distinct())
        {
            var (result, ms) = await Bench.MeasureAsync(
                $"Producer-Consumer (consumers={degree})",
                () => new ProducerConsumerPattern(degree).RunAsync(transactions));
            PrintResult(result);
            Bench.PrintSpeedup(seqMs, ms, "Producer-Consumer", degree);
        }
    }

    private static AggregationResult RunSequential(List<Transaction> transactions)
    {
        long count = 0;
        decimal totalAmount = 0;
        decimal totalCashback = 0;
        decimal totalFinal = 0;
        long cashbackCount = 0;

        foreach (var tx in transactions)
        {
            decimal amountUah = TransactionProcessor.ConvertToUah(tx);
            decimal cashback = TransactionProcessor.CalculateCashback(tx, amountUah);
            var processed = TransactionProcessor.Finalize(tx, amountUah, cashback);

            count++;
            totalAmount += processed.AmountUah;
            totalCashback += processed.CashbackUah;
            totalFinal += processed.FinalAmountUah;
            if (processed.CashbackUah > 0) cashbackCount++;
        }

        return new AggregationResult(count, totalAmount, totalCashback, totalFinal, cashbackCount);
    }

    private static void PrintResult(AggregationResult result)
    {
        Console.WriteLine($"    Transactions      : {result.TotalTransactions:N0}");
        Console.WriteLine($"    Total UAH         : {result.TotalAmountUah:N2}");
        Console.WriteLine($"    Cashback UAH      : {result.TotalCashbackUah:N2}");
        Console.WriteLine($"    Final UAH         : {result.TotalFinalAmountUah:N2}");
        Console.WriteLine($"    Cashback eligible : {result.CashbackEligibleCount:N0}");
    }
}
