using NTUU.KPI.ParallelThreadingLab2.Features.Task1.ArrayStats.Services;
using NTUU.KPI.ParallelThreadingLab2.Features.Task1.ArrayStats.Strategies;
using NTUU.KPI.ParallelThreadingLab2.Features.Task1.Html.Services;
using NTUU.KPI.ParallelThreadingLab2.Features.Task1.Html.Strategies;
using NTUU.KPI.ParallelThreadingLab2.Features.Task1.Matrics.Services;
using NTUU.KPI.ParallelThreadingLab2.Features.Task1.Matrics.Strategies;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.ArrayStats.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Html.Interfaces;
using NTUU.KPI.ParallelThreadingLab2.Task1.Features.Matrics.Interfaces;

var parser = new HtmlTagParser();
var generator = new HtmlDocumentGenerator();

Console.WriteLine("Machine Processor Count: " + Environment.ProcessorCount);
Console.WriteLine("Machine OS Version: " + Environment.OSVersion);

Console.WriteLine($"\n{new string('=', 50)} Task1 {new string('=', 50)}");

var degrees = new HashSet<int>(
    [
        2,
        4,
        Environment.ProcessorCount / 4,
        Environment.ProcessorCount / 3,
        Environment.ProcessorCount / 2,
        Environment.ProcessorCount,
        Environment.ProcessorCount + Environment.ProcessorCount / 4,
        Environment.ProcessorCount + Environment.ProcessorCount / 3,
        Environment.ProcessorCount + Environment.ProcessorCount / 2,
    ]);

ITagFrequencyStrategy[] strategies =
[
    new HtmlSequentialStrategy(parser),
    ..degrees.Select(degree => new HtmlPlinqMapReduceStrategy(parser, degree)),
    ..degrees.Select(degree => new HtmlForkJoinStrategy(parser, degree)),
    ..degrees.Select(degree => new HtmlDataflowWorkerPoolStrategy(parser, degree)),
];

await new HtmlTagFrequency(generator, strategies).RunAsync();

IArrayStatsStrategy[] arrayStatsStrategies =
[
    new ArraySequentialStrategy(),
    ..degrees.Select(degree => new ArrayStatsPlinqMapReduceStrategy(degree)),
    ..degrees.Select(degree => new ArrayStatsForkJoinStrategy(degree)),
    ..degrees.Select(degree => new ArrayStatsDataflowWorkerPoolStrategy(degree)),
];

await new ArrayStatsRunner(arrayStatsStrategies).RunAsync();


IMatrixMultiplyStrategy[] matrixStrategies =
[
    new MatrixSequentialStrategy(),
    ..degrees.Select(degree => new MatrixPlinqMapReduceStrategy(degree)),
    ..degrees.Select(degree => new MatrixForkJoinStrategy(degree)),
    ..degrees.Select(degree => new MatrixDataflowWorkerPoolStrategy(degree)),
];

await new MatrixMultiplyRunner(matrixStrategies).RunAsync();

Console.WriteLine($"\n{new string('=', 50)} Task2 {new string('=', 50)}");
