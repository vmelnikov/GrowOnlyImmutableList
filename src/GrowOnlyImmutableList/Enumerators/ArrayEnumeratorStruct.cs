using System.Collections;

namespace Mvo.GrowOnlyImmutableList.Enumerators;

public struct ArrayEnumeratorStruct<T>
{
    private int _index;
    private readonly int _size;
    private readonly T[] _items;

    internal ArrayEnumeratorStruct(T[] items, int size)
    {
        _size = size;
        _items  = items;
        _index = -1;
    }
    
    public bool MoveNext() => 
        ++_index < _size;
    

    public T Current => 
        _items[_index];
}