using System.Collections;

namespace Mvo.GrowOnlyImmutableList;

public class GrowOnlyImmutableList<T> : IGrowOnlyImmutableList<T>
{
    private const int DefaultCapacity = 4;
    private readonly T[] _items;
    private int _growAttemptsCount;

    public GrowOnlyImmutableList()
    {
        _items = Array.Empty<T>();
    }

    public GrowOnlyImmutableList(int capacity)
    {
        _items = new T[capacity];
    }

    private GrowOnlyImmutableList(T[] items, int count)
    {
        _items = items;
        Count = count;
    }

    public int Count { get; }

    public T this[int index] =>
        _items[index];

    public IGrowOnlyImmutableList<T> Add(T value)
    {
        var growAttemptsCount = Interlocked.Increment(ref _growAttemptsCount);
        var items = Count == _items.Length ? GrowItems() : GetItems(growAttemptsCount > 1);
        items[Count] = value;
        return new GrowOnlyImmutableList<T>(items, Count + 1);
    }

    private T[] GetItems(bool asCopy)
    {
        if (!asCopy)
            return _items;
        var newItems = new T[_items.Length];
        Array.Copy(_items, newItems, Count);
        return newItems;
    }

    /// <summary>
    /// Grow array twice and copy items into it
    /// </summary>
    /// <returns>Array with new capacity</returns>
    private T[] GrowItems()
    {
        var capacity = _items.Length;
        var newCapacity = capacity == 0 ? DefaultCapacity : capacity * 2;
        if ((uint)newCapacity > int.MaxValue)
            newCapacity = int.MaxValue;
        var newItems = new T[newCapacity];
        Array.Copy(_items, newItems, Count);
        return newItems;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
            yield return _items[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}