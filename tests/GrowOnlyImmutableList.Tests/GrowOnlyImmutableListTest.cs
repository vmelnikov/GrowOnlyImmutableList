using Mvo.GrowOnlyImmutableList;
using Xunit;

namespace GrowOnlyImmutableList.Tests;

public class GrowOnlyImmutableListTest
{
    [Fact]
    public void Test1()
    {
        const int count = 100000;
        var list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < count; i++)
            list = list.Add(i);
        Assert.Equal(count, list.Count);
    }
    
    [Fact]
    public void AddRangeTest()
    {
        var itemsForAdd = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        const int addCount = 1000;
        var list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < addCount; i++)
            list = list.AddRange(itemsForAdd);
        Assert.Equal(addCount * itemsForAdd.Length, list.Count);
    }
}