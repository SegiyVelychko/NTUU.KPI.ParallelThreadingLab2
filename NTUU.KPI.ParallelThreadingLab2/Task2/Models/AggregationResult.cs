namespace NTUU.KPI.ParallelThreadingLab2.Task2.Models;

public sealed record AggregationResult(
    long TotalTransactions,
    decimal TotalAmountUah,
    decimal TotalCashbackUah,
    decimal TotalFinalAmountUah,
    long CashbackEligibleCount);
