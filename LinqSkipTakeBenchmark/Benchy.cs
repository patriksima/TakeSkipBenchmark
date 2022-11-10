using System.Collections;
using BenchmarkDotNet.Attributes;

namespace LinqSkipTakeBenchmark;

[MemoryDiagnoser()]
public class Benchy
{
    public static readonly long[] ArrayOfLong = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public static readonly ArrayList ArrayListOfLong = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public static readonly List<long> ListOfLong = new List<long> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    [Benchmark]
    public int ArrayTest()
    {
        var result = new ArraySegment<long>(ArrayOfLong, 5, 5);
        return result.Count;
    }
    
    [Benchmark]
    public int ArrayListTest()
    {
        var result = ArrayListOfLong.GetRange(5,5);
        return result.Count;
    }
    
    [Benchmark]
    public int ListTest()
    {
        var result = ListOfLong.Take(5).Skip(5);
        return result.Count();
    }
}