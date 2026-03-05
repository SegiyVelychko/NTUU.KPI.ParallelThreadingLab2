using NTUU.KPI.ParallelThreadingLab2.Task2.Models;
using NTUU.KPI.ParallelThreadingLab2.Task2.Models.Enums;

namespace NTUU.KPI.ParallelThreadingLab2.Task2.Services;

public static class TransactionProcessor
{
    /// <summary>UserId > threshold → 20% cashback on converted UAH amount.</summary>
    public const long CashbackThreshold = 10_000_000; // Bogus generates UserId in 8 symbol"

    private static readonly Dictionary<Currency, decimal> RatesToUah = new()
    {
        [Currency.USD] = 41.5m,
        [Currency.EUR] = 45.2m,
        [Currency.GBP] = 52.8m,
        [Currency.UAH] = 1.0m,
    };

    /// <summary>Step 1 — Convert USD amount to target currency, then to UAH.</summary>
    public static decimal ConvertToUah(Transaction tx)
    {
        decimal rate = RatesToUah[tx.Currency];
        return Math.Round(tx.AmountUsd * rate, 2);
    }

    /// <summary>Step 2 — 20% cashback for premium users (UserId > threshold).</summary>
    public static decimal CalculateCashback(Transaction tx, decimal amountUah) =>
        tx.UserId > CashbackThreshold
            ? Math.Round(amountUah * 0.20m, 2)
            : 0m;

    /// <summary>Step 3 — Assemble final processed record.</summary>
    public static ProcessedTransaction Finalize(Transaction tx, decimal amountUah, decimal cashbackUah) =>
        new(
            TransactionId: tx.TransactionId,
            AccountId: tx.AccountId,
            OriginalAmountUsd: tx.AmountUsd,
            OriginalCurrency: tx.Currency,
            AmountUah: amountUah,
            CashbackUah: cashbackUah,
            FinalAmountUah: amountUah - cashbackUah);
}
