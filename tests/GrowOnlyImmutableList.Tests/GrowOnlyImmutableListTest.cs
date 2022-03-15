using Mvo.GrowOnlyImmutableList;
using Xunit;

namespace GrowOnlyImmutableList.Tests;

public class GrowOnlyImmutableListTest
{
    [Fact]
    public void Test1()
    {
        const int count = 100000;
        IGrowOnlyImmutableList<int> list = new GrowOnlyImmutableList<int>();
        for (var i = 0; i < count; i++)
            list = list.Add(i);
        Assert.Equal(count, list.Count);
    }
}