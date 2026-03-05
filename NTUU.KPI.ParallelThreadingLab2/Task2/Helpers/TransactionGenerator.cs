using Bogus;
using NTUU.KPI.ParallelThreadingLab2.Task2.Models;
using NTUU.KPI.ParallelThreadingLab2.Task2.Models.Enums;

namespace NTUU.KPI.ParallelThreadingLab2.Task2.Helpers;

public static class TransactionGenerator
{
    private const int Seed = 42;

    public static List<Transaction> Generate(int count)
    {
        // UserId range: 1..20 — so ~half will be > threshold (10) and get cashback
        var faker = new Faker<Transaction>()
            .CustomInstantiator(f => new Transaction(
                TransactionId: f.Random.Guid().ToString(),
                AccountId: f.Finance.Account(),
                AmountUsd: Math.Round(f.Finance.Amount(1, 5000), 2),
                Currency: f.PickRandom<Currency>(),
                ProductType: f.PickRandom<ProductType>(),
                CardType: f.PickRandom<CardType>(),
                Country: f.Address.CountryCode(),
                UserId: f.Random.Long(1, 20),
                Date: f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2024, 12, 31))
            ));

        Randomizer.Seed = new Random(Seed);
        return faker.Generate(count);
    }
}
