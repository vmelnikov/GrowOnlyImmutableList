using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;
using Mvo.GrowOnlyImmutableList;

namespace GrowOnlyImmutableList.Benchmarks;

[MemoryDiagnoser]
public class AddBenchmark
{
    private const int Count = 10000;

    private readonly IList<int> _list;
    private readonly IGrowOnlyImmutableList<int> _growOnlyImmutableList;
    private readonly IImmutableList<int> _immutableList;
    private readonly ImmutableArray<int> _immutableArray;

    public AddBenchmark()
    {
        var list = new List<int>(Count);
        IGrowOnlyImmutableList<int> growOnlyImmutableList = new GrowOnlyImmutableList<int>(Count);
        for (var i = 0; i < Count; i++)
        {
            list.Add(i);
            growOnlyImmutableList = growOnlyImmutableList.Add(i);
        }

        _list = list;
        _growOnlyImmutableList = growOnlyImmutableList;
        _immutableList = list.ToImmutableList();
        _immutableArray = list.ToImmutableArray();


    }
    
    [Benchmark]
    public void GrowOnlyImmutableListAdd()
    {
        IGrowOnlyImmutableList<int> list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < Count; i++)
            list = list.Add(i);
    }
    
    [Benchmark]
    public void ListAdd()
    {
        IList<int> list = new List<int>();
        for (var i = 0; i < Count; i++)
            list.Add(i);
    }
    
    [Benchmark]
    public void ImmutableListAdd()
    {
        var list = ImmutableList<int>.Empty;
        for (var i = 0; i < Count; i++)
            list = list.Add(i);
    }
    
    [Benchmark]
    public void ImmutableArrayAdd()
    {
        var array = ImmutableArray<int>.Empty;
        for (var i = 0; i < Count; i++)
            array = array.Add(i);
    }
    
    
    [Benchmark]
    public void GrowOnlyImmutableListForeach()
    {
        foreach (var item in _growOnlyImmutableList)
        {
        }
    }
    
    [Benchmark]
    public void ListForeach()
    {
        foreach (var item in _list)
        {
        }
    }
    
    [Benchmark]
    public void ImmutableListForeach()
    {
        foreach (var item in _immutableList)
        {
        }
    }
    
    [Benchmark]
    public void ImmutableArrayForeach()
    {
        foreach (var item in _immutableArray)
        {
        }
    }
    
    [Benchmark]
    public void GrowOnlyImmutableListFor()
    {
        var value = 0;
        for (var i = 0; i < _growOnlyImmutableList.Count; i++)
            value = _growOnlyImmutableList[i];

    }
    
    [Benchmark]
    public void ListFor()
    {
        var value = 0;
        for (var i = 0; i < _list.Count; i++)
            value = _list[i];
    }
    
    [Benchmark]
    public void ImmutableListFor()
    {
        var value = 0;
        for (var i = 0; i < _immutableList.Count; i++)
            value = _immutableList[i];
    }
    
    [Benchmark]
    public void ImmutableArrayFor()
    {
        var value = 0;
        for (var i = 0; i < _immutableArray.Length; i++)
            value = _immutableArray[i];
    }
}