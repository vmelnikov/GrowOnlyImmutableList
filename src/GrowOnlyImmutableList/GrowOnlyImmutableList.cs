using System.Collections;
using Mvo.GrowOnlyImmutableList.Enumerators;

namespace Mvo.GrowOnlyImmutableList;

/// <summary>
/// Represents a strongly typed threadsafe immutable list of objects that can be accessed by index. Provide only add items method
/// </summary>
/// <typeparam name="T">The type of elements in the list.</typeparam>
public class GrowOnlyImmutableList<T> : IGrowOnlyImmutableList<T>
{
    private const int DefaultCapacity = 4;
    private readonly T[] _items;
    private int _growAttemptsCount;

    /// <summary>
    /// Initializes a new instance of the <see cref="GrowOnlyImmutableList{T}" /> class that is empty and has the default initial capacity.
    /// </summary>
    public GrowOnlyImmutableList()
    {
        _items = Array.Empty<T>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GrowOnlyImmutableList{T}" /> class that is empty and has the specified initial capacity.
    /// </summary>
    /// <param name="capacity">The number of elements that the new list can initially store.</param>
    public GrowOnlyImmutableList(int capacity)
    {
        _items = new T[capacity];
    }

    private GrowOnlyImmutableList(T[] items, int size)
    {
        _items = items;
        Count = size;
    }

    /// <inheritdoc cref="IReadOnlyCollection{T}"/>
    public int Count { get; }

    /// <inheritdoc cref="IReadOnlyList{T}"/>
    public T this[int index] =>
        _items[index];

    public ArrayEnumeratorStruct<T> GetEnumerator() =>
        new(_items, Count);
    
    /// <inheritdoc/>
    IEnumerator<T> IEnumerable<T>.GetEnumerator() =>
        new ArrayEnumeratorObject<T>(_items, Count);

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() =>
        new ArrayEnumeratorObject<T>(_items, Count);

    /// See the <see cref="IGrowOnlyImmutableList{T}"/> interface.
    public GrowOnlyImmutableList<T> Add(T value)
    {
        var growAttemptsCount = Interlocked.Increment(ref _growAttemptsCount);
        //We must create a copy of items array if Add method called twice or more for one instance of list
        var items = Count == _items.Length ? GrowItems() : GetItems(growAttemptsCount > 1);
        items[Count] = value;
        return new GrowOnlyImmutableList<T>(items, Count + 1);
    }

    /// See the <see cref="IGrowOnlyImmutableList{T}"/> interface.
    IGrowOnlyImmutableList<T> IGrowOnlyImmutableList<T>.Add(T value) => Add(value);


    private T[] GetItems(bool asCopy)
    {
        if (!asCopy)
            return _items;
        var newItems = new T[_items.Length];
        Array.Copy(_items, newItems, Count);
        return newItems;
    }

    /// <summary>
    /// Increases capacity of items array to twice the current capacity and copy items into it
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
}