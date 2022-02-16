namespace Mvo.GrowOnlyImmutableList;

public interface IGrowOnlyImmutableList<T> : IReadOnlyList<T>
{
    IGrowOnlyImmutableList<T> Add(T value);
}