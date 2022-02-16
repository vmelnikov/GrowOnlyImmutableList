using System.Collections;

namespace Mvo.GrowOnlyImmutableList;

public class GrowOnlyImmutableList<T> : IGrowOnlyImmutableList<T>
{
    public IGrowOnlyImmutableList<T> Add(T value)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count { get; }

    public T this[int index] => throw new NotImplementedException();
}