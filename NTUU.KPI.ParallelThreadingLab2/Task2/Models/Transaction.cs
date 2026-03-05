using NTUU.KPI.ParallelThreadingLab2.Task2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTUU.KPI.ParallelThreadingLab2.Task2.Models
{
    public sealed record Transaction(
        string TransactionId,
        string AccountId,
        decimal AmountUsd,
        Currency Currency,
        ProductType ProductType,
        CardType CardType,
        string Country,
        long UserId,       // numeric — used for cashback eligibility (> threshold → 20%)
        DateTime Date);
}
