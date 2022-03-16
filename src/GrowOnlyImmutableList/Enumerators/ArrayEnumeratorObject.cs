using System.Collections;

namespace Mvo.GrowOnlyImmutableList.Enumerators;

public struct ArrayEnumeratorObject<T> : IEnumerator<T>
{
    private int _index;
    private readonly int _size;
    private readonly T[] _items;

    internal ArrayEnumeratorObject(T[] items, int size)
    {
        _size = size;
        _items  = items;
        _index = -1;
    }
    
    public bool MoveNext() => 
        ++_index < _size;

    public void Reset() => 
        _index = -1;

    public T Current => 
        _items[_index];

    object? IEnumerator.Current => 
        Current;

    public void Dispose()
    {
    }
}