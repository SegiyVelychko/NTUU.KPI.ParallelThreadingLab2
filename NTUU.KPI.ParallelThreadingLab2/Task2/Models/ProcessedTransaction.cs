using NTUU.KPI.ParallelThreadingLab2.Task2.Models.Enums;

namespace NTUU.KPI.ParallelThreadingLab2.Task2.Models;

public sealed record ProcessedTransaction(
    string TransactionId,
    string AccountId,
    decimal OriginalAmountUsd,
    Currency OriginalCurrency,
    decimal AmountUah,
    decimal CashbackUah,
    decimal FinalAmountUah);
