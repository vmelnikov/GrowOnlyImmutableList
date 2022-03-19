namespace Mvo.GrowOnlyImmutableList;

public interface IGrowOnlyImmutableList<T> : IReadOnlyList<T>
{
    /// <summary>
    /// Adds given object to the end of the <see cref="GrowOnlyImmutableList{T}" />
    /// </summary>
    /// <param name="value">The object to be added</param>
    /// <returns>New list with added object</returns>
    IGrowOnlyImmutableList<T> Add(T value);
    
    /// <summary>
    /// Adds the elements of the specified collection to the end of the <see cref="GrowOnlyImmutableList{T}" />.
    /// </summary>
    /// <param name="collection">The collection whose elements should be added to the end of the <see cref="GrowOnlyImmutableList{T}" />.</param>
    /// <returns>New list with added object</returns>
    IGrowOnlyImmutableList<T> AddRange(IEnumerable<T> collection);
}