using Mvo.GrowOnlyImmutableList;
using Xunit;

namespace GrowOnlyImmutableList.Tests;

public class GrowOnlyImmutableListTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(10000)]
    public void ItemsCount_ShouldBeCorrectAfter_Add(int count)
    {
        var list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < count; i++)
            list = list.Add(i);
        Assert.Equal(count, list.Count);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void ItemsCount_ShouldBeCorrectAfter_AddRange(int addCount)
    {
        var itemsForAdd = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < addCount; i++)
            list = list.AddRange(itemsForAdd);
        Assert.Equal(addCount * itemsForAdd.Length, list.Count);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void Call_AddMethod_Twice_Should_CreateDifferentInstances(int initCount)
    {
        const int value1 = 123;
        const int value2 = 321;
        var list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < initCount; i++)
            list = list.Add(i);
        var newList1 = list.Add(value1);
        var newList2 = list.Add(value2);
        Assert.NotEqual(newList1, newList2);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void Call_AddMethod_Twice_Should_CreateInstances_With_CorrectItemsCount(int initCount)
    {
        const int value1 = 123;
        const int value2 = 321;
        var list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < initCount; i++)
            list = list.Add(i);
        var newList1 = list.Add(value1);
        var newList2 = list.Add(value2);
        Assert.Equal(list.Count + 1, newList1.Count);
        Assert.Equal(list.Count + 1, newList2.Count);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void Call_AddMethod_Twice_Should_CreateInstances_With_CorrectLastItem(int initCount)
    {
        const int value1 = 123;
        const int value2 = 321;
        var list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < initCount; i++)
            list = list.Add(i);
        var newList1 = list.Add(value1);
        var newList2 = list.Add(value2);
        Assert.Equal(value1, newList1[^1]);
        Assert.Equal(value2, newList2[^1]);
    }
}