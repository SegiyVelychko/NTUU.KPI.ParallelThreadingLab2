using NTUU.KPI.ParallelThreadingLab2.Task2.Models;
using System.Threading.Tasks.Dataflow;

namespace NTUU.KPI.ParallelThreadingLab2.Task2.Services;

public sealed class PipelinePattern
{
    private readonly int _maxDegree;

    public PipelinePattern(int maxDegree = 4) => _maxDegree = maxDegree;

    public async Task<AggregationResult> RunAsync(IEnumerable<Transaction> transactions)
    {
        // ── Accumulators (Stage 3 is MaxDop=1, so no locks needed) ────────
        long count = 0;
        decimal totalAmount = 0;
        decimal totalCashback = 0;
        decimal totalFinal = 0;
        long cashbackCount = 0;

        // ── Stage 1: Currency conversion ───────────────────────────────────
        var convertBlock = new TransformBlock<Transaction, (Transaction Tx, decimal AmountUah)>(
            tx =>
            {
                decimal uah = TransactionProcessor.ConvertToUah(tx);
                return (tx, uah);
            },
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _maxDegree,
                BoundedCapacity = _maxDegree * 16,
            });

        // ── Stage 2: Cashback calculation ──────────────────────────────────
        var cashbackBlock = new TransformBlock<(Transaction Tx, decimal AmountUah), ProcessedTransaction>(
            item =>
            {
                decimal cashback = TransactionProcessor.CalculateCashback(item.Tx, item.AmountUah);
                return TransactionProcessor.Finalize(item.Tx, item.AmountUah, cashback);
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
        convertBlock.LinkTo(cashbackBlock, linkOptions);
        cashbackBlock.LinkTo(aggregateBlock, linkOptions);

        // ── Produce ────────────────────────────────────────────────────────
        foreach (var tx in transactions)
            await convertBlock.SendAsync(tx);

        convertBlock.Complete();
        await aggregateBlock.Completion;

        return new AggregationResult(count, totalAmount, totalCashback, totalFinal, cashbackCount);
    }
}
