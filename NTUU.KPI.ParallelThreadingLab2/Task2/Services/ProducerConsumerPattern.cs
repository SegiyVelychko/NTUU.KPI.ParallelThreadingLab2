using NTUU.KPI.ParallelThreadingLab2.Task2.Models;
using System.Threading.Channels;

namespace NTUU.KPI.ParallelThreadingLab2.Task2.Services;

public sealed class ProducerConsumerPattern(int consumerCount = 4)
{
    private readonly int _consumerCount = consumerCount;

    public async Task<AggregationResult> RunAsync(IEnumerable<Transaction> transactions)
    {
        var channel = Channel.CreateBounded<Transaction>(new BoundedChannelOptions(_consumerCount * 32)
        {
            SingleWriter = true,
            SingleReader = false,
            FullMode = BoundedChannelFullMode.Wait,  // back-pressure: producer waits
        });

        var producer = Task.Run(async () =>
        {
            foreach (var tx in transactions)
                await channel.Writer.WriteAsync(tx);

            channel.Writer.Complete();
        });

        var consumers = Enumerable.Range(0, consumerCount).Select(_ => Task.Run(async () =>
        {
            long count = 0;
            long eligible = 0;

            decimal total = 0;
            decimal cashback = 0;
            decimal final = 0;

            await foreach (var tx in channel.Reader.ReadAllAsync())
            {
                decimal uah = TransactionProcessor.ConvertToUah(tx);
                decimal cb = TransactionProcessor.CalculateCashback(tx, uah);
                decimal finalUah = uah - cb;

                count++;
                total += uah;
                cashback += cb;
                final += finalUah;
                if (cb > 0) eligible++;
            }
            return (Count: count, Total: total, Cashback: cashback, Final: final, Eligible: eligible);
        })).ToArray();

        await producer;
        var partials = await Task.WhenAll(consumers);

        var result = partials.Aggregate((a, b) => (
            Count: a.Count + b.Count,
            Total: a.Total + b.Total,
            Cashback: a.Cashback + b.Cashback,
            Final: a.Final + b.Final,
            Eligible: a.Eligible + b.Eligible));

        return new AggregationResult(
            result.Count,
            result.Total,
            result.Cashback,
            result.Final,
            result.Eligible);
    }
}
