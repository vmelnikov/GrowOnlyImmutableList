namespace Mvo.GrowOnlyImmutableList;

public interface IGrowOnlyImmutableList<T> : IReadOnlyList<T>
{
    /// <summary>
    /// Adds given object to the end of the list
    /// </summary>
    /// <param name="value">The object to be added</param>
    /// <returns>New list with added object</returns>
    IGrowOnlyImmutableList<T> Add(T value);
}