namespace Fermion.Domain.Shared.Abstractions;

/// <summary>
/// Interface for objects that support soft deletion.
/// </summary>
public interface ISoftDelete
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity is deleted.
    /// </summary>
    bool IsDeleted { get; set; }
}