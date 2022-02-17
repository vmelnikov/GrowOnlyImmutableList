using System.Collections.Concurrent;

namespace Mvo.GrowOnlyImmutableList;

internal class GrowOnlyBuffer<T> : IGrowOnlyBuffer<T>
{
    private const int DefaultCapacity = 256;

    private readonly T[] _items;
    private bool _frozen;


    public GrowOnlyBuffer()
    {
        _items = new T[DefaultCapacity];
    }
    
    public GrowOnlyBuffer(int capacity)
    {
        _items = new T[capacity];
    }

    private GrowOnlyBuffer(T[] items, int count)
    {
        _items = items;
        Count = count;
    }

    public int Count { get; }

    public int Capacity => _items.Length;


    public bool IsFull => Count == Capacity;


    public IGrowOnlyBuffer<T> Add(T value)
    {
        if (_frozen)
            throw new InvalidOperationException("you can't add item twice");
        if (Count == Capacity)
            throw new OverflowException();
        _items[Count] = value;
        Freeze();
        return new GrowOnlyBuffer<T>(_items, Count + 1);
    }

    private void Freeze() =>
        _frozen = true;

}