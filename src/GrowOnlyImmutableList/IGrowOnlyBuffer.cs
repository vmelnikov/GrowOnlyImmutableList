namespace Mvo.GrowOnlyImmutableList;

internal interface IGrowOnlyBuffer<T>
{
    public int Count { get; }

    public int Capacity { get; }
    
    
    public bool IsFull { get; }

    public IGrowOnlyBuffer<T> Add(T value);
}