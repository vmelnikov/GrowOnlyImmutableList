using System.Collections;

namespace Mvo.GrowOnlyImmutableList.Enumerators;

/// <summary>
/// Represents an array enumerator that implements <see cref="IEnumerator{T}"/> pattern (including <see cref="IDisposable"/>).
/// </summary>
public struct ArrayEnumeratorObject<T> : IEnumerator<T>
{
    private int _index;
    private readonly int _size;
    private readonly T[] _items;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayEnumeratorObject{T}"/> class.
    /// </summary>
    internal ArrayEnumeratorObject(T[] items, int size)
    {
        _size = size;
        _items  = items;
        _index = -1;
    }
    
    /// <inheritdoc/>
    public bool MoveNext() => 
        ++_index < _size;

    /// <inheritdoc/>
    public void Reset() => 
        _index = -1;

    /// <inheritdoc/>
    public T Current => 
        _items[_index];

    /// <inheritdoc/>
    object? IEnumerator.Current => 
        Current;

    /// <inheritdoc/>
    public void Dispose()
    {
        // Currently has no action.
    }
}