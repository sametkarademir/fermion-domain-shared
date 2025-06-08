namespace Fermion.Domain.Shared.Abstractions;

/// <summary>
/// Interface for objects that track their creation time.
/// </summary>
public interface IHasCreationTime
{
    /// <summary>
    /// Gets or sets the creation time of the entity.
    /// </summary>
    DateTime CreationTime { get; set; }
}