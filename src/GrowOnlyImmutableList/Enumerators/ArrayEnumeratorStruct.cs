using System.Collections;

namespace Mvo.GrowOnlyImmutableList.Enumerators;

/// <summary>
/// Represents an array enumerator without <see cref="IDisposable"/> implementation
/// </summary>
/// <remarks>
/// Used to improve performance when we do foreach
/// </remarks>
public struct ArrayEnumeratorStruct<T>
{
    private int _index;
    private readonly int _size;
    private readonly T[] _items;

    /// <summary>
    /// Creates an enumerator for the specified array.
    /// </summary>
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