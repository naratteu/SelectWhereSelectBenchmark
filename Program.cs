using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<SelectWhereSelectBenchmark>();

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net481)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80)]
[RPlotExporter]
[MarkdownExporter]
public class SelectWhereSelectBenchmark
{
    readonly byte[] data = new byte[5000000];
    public SelectWhereSelectBenchmark() => new Random(42).NextBytes(data);

    [Benchmark] public byte[] query() => data.SelectWhen1(i => (i % 2 is 1, i)).ToArray();
    [Benchmark] public byte[] ramda() => data.SelectWhen2(i => (i % 2 is 1, i)).ToArray();
    [Benchmark] public byte[] tuple() => data.SelectWhen3(i => (i % 2 is 1, i)).ToArray();
    [Benchmark] public byte[] destruct() => data.SelectWhen4(i => (i % 2 is 1, i)).ToArray();
}

static class SelectWhereSelectExtensions
{
    public static IEnumerable<T> SelectWhen1<Tin, T>(this IEnumerable<Tin> tin, Func<Tin, (bool b, T t)> f) => from bt in tin.Select(f) where bt.b select bt.t;
    public static IEnumerable<T> SelectWhen2<Tin, T>(this IEnumerable<Tin> tin, Func<Tin, (bool b, T t)> f) => tin.Select(f).Where(bt => bt.b).Select(bt => bt.t);
    public static IEnumerable<T> SelectWhen3<Tin, T>(this IEnumerable<Tin> tin, Func<Tin, (bool b, T t)> f) { foreach (var bt in tin.Select(f)) if (bt.b) yield return bt.t; }
    public static IEnumerable<T> SelectWhen4<Tin, T>(this IEnumerable<Tin> tin, Func<Tin, (bool b, T t)> f) { foreach (var (b, t) in tin.Select(f)) if (b) yield return t; }
}