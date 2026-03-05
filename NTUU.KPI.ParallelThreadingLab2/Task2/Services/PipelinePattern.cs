using NTUU.KPI.ParallelThreadingLab2.Task2.Models;
using System.Threading.Tasks.Dataflow;

namespace NTUU.KPI.ParallelThreadingLab2.Task2.Services;

public sealed class PipelinePattern(int maxDegree = 4)
{
    private readonly int _maxDegree = maxDegree;

    public async Task<AggregationResult> RunAsync(IEnumerable<Transaction> transactions)
    {
        // ── Accumulators (Stage 3 is MaxDop=1, so no locks needed) ────────
        long count = 0;
        decimal totalAmount = 0;
        decimal totalCashback = 0;
        decimal totalFinal = 0;
        long cashbackCount = 0;

        // ── Stage 1: Currency conversion ───────────────────────────────────
        var processBlock = new TransformBlock<Transaction, ProcessedTransaction>(
            tx =>
            {
                decimal uah = TransactionProcessor.ConvertToUah(tx);
                decimal cashback = TransactionProcessor.CalculateCashback(tx, uah);
                return TransactionProcessor.Finalize(tx, uah, cashback);
            },
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _maxDegree,
                BoundedCapacity = _maxDegree * 16,
            });

        // ── Stage 3: Aggregation (single consumer — no locking) ────────────
        var aggregateBlock = new ActionBlock<ProcessedTransaction>(
            tx =>
            {
                count++;
                totalAmount += tx.AmountUah;
                totalCashback += tx.CashbackUah;
                totalFinal += tx.FinalAmountUah;
                if (tx.CashbackUah > 0) cashbackCount++;
            },
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = 1,   // single consumer: safe to mutate without locks
                BoundedCapacity = _maxDegree * 16,
            });

        // ── Link stages ────────────────────────────────────────────────────
        var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
        processBlock.LinkTo(aggregateBlock, linkOptions);

        // ── Produce ────────────────────────────────────────────────────────
        foreach (var tx in transactions)
            await processBlock.SendAsync(tx);

        processBlock.Complete();
        await aggregateBlock.Completion;

        return new AggregationResult(count, totalAmount, totalCashback, totalFinal, cashbackCount);
    }
}
