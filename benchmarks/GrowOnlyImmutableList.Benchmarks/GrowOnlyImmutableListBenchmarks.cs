using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;
using Mvo.GrowOnlyImmutableList;

namespace GrowOnlyImmutableList.Benchmarks;

[MemoryDiagnoser]
public class GrowOnlyImmutableListBenchmarks
{
    private const int Count = 100000;

    private List<int> _list = new();
    private GrowOnlyImmutableList<int> _growOnlyImmutableList = new();
    private ImmutableList<int> _immutableList = ImmutableList<int>.Empty;
    private ImmutableArray<int> _immutableArray;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var list = new List<int>(Count);
        var growOnlyImmutableList = new GrowOnlyImmutableList<int>(Count);
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
    public void GrowOnlyImmutableList_Add()
    {
        IGrowOnlyImmutableList<int> list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < Count; i++)
            list = list.Add(i);
    }
    
    [Benchmark]
    public void List_Add()
    {
        IList<int> list = new List<int>();
        for (var i = 0; i < Count; i++)
            list.Add(i);
    }
    
    [Benchmark]
    public void ImmutableList_Add()
    {
        var list = ImmutableList<int>.Empty;
        for (var i = 0; i < Count; i++)
            list = list.Add(i);
    }
    
    [Benchmark]
    public void ImmutableArray_Add()
    {
        var array = ImmutableArray<int>.Empty;
        for (var i = 0; i < Count; i++)
            array = array.Add(i);
    }
 
    [Benchmark]
    public int GrowOnlyImmutableList_For()
    {
        var res = 0;
        for (var i = 0; i < _growOnlyImmutableList.Count; i++)
            res  += _growOnlyImmutableList[i];
        return res;
    }
    
    [Benchmark]
    public int List_For()
    {
        var res = 0;
        for (var i = 0; i < _list.Count; i++)
            res  += _list[i];
        return res;
    }
    
    [Benchmark]
    public int ImmutableList_For()
    {
        var res = 0;
        for (var i = 0; i < _immutableList.Count; i++)
            res  += _immutableList[i];
        return res;
    }
    
    [Benchmark]
    public int ImmutableArray_For()
    {
        var res = 0;
        for (var i = 0; i < _immutableArray.Length; i++)
            res += _immutableArray[i];
        return res;
    }
    

    [Benchmark]
    public int GrowOnlyImmutableList_Foreach()
    {
        var res = 0;
        foreach (var item in _growOnlyImmutableList)
            res += item;
        return res;
    }

    [Benchmark]
    public int List_Foreach()
    {
        var res = 0;
        foreach (var item in _list)
            res += item;
        return res;
    }

    [Benchmark]
    public int ImmutableList_Foreach()
    {
        var res = 0;
        foreach (var item in _immutableList)
            res += item;
        return res;
    }

    [Benchmark]
    public int ImmutableArray_Foreach()
    {
        var res = 0;
        foreach (var item in _immutableArray)
            res += item;
        return res;
    }
}