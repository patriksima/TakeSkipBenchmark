using System.Collections;
using BenchmarkDotNet.Attributes;

namespace LinqSkipTakeBenchmark;

public class SimpleObject
{
    public SimpleObject(long id, decimal amount, string note)
    {
        Id = id;
        Amount = amount;
        Note = note;
    }

    public long Id { get; }
    public decimal Amount { get; }
    public string Note { get; }
}

[MemoryDiagnoser]
public class Benchy
{
    public static readonly long[] ArrayOfLong = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public static readonly ArrayList ArrayListOfLong = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public static readonly List<long> ListOfLong = new List<long> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    public static readonly SimpleObject[] ArrayOfObject = new SimpleObject[]
    {
        new(1, 1.123m, "Note1"),
        new(2, 1.123m, "Note2"),
        new(3, 1.123m, "Note3"),
        new(4, 1.123m, "Note4"),
        new(5, 1.123m, "Note5"),
        new(6, 1.123m, "Note6"),
        new(7, 1.123m, "Note7"),
        new(8, 1.123m, "Note8"),
        new(9, 1.123m, "Note9"),
        new(10, 1.123m, "Note10")
    };

    public static readonly List<SimpleObject> ListOfObject = new List<SimpleObject>
    {
        new(1, 1.123m, "Note1"),
        new(2, 1.123m, "Note2"),
        new(3, 1.123m, "Note3"),
        new(4, 1.123m, "Note4"),
        new(5, 1.123m, "Note5"),
        new(6, 1.123m, "Note6"),
        new(7, 1.123m, "Note7"),
        new(8, 1.123m, "Note8"),
        new(9, 1.123m, "Note9"),
        new(10, 1.123m, "Note10")
    };

    [Benchmark]
    public int ArrayOfObjectTest()
    {
        var result = new ArraySegment<SimpleObject>(ArrayOfObject, 5, 5);
        return result.Count;
    }

    [Benchmark]
    public int ListOfObjectTest()
    {
        var result = ListOfObject.Skip(5).Take(5);
        return result.Count();
    }

    [Benchmark]
    public int ArrayOfLongTest()
    {
        var result = new ArraySegment<long>(ArrayOfLong, 5, 5);
        return result.Count;
    }

    [Benchmark]
    public int ArrayListOfLongTest()
    {
        var result = ArrayListOfLong.GetRange(5, 5);
        return result.Count;
    }

    [Benchmark]
    public int ListOfLongTest()
    {
        var result = ListOfLong.Take(5).Skip(5);
        return result.Count();
    }
}