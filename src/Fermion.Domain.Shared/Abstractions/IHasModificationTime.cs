namespace Fermion.Domain.Shared.Abstractions;

/// <summary>
/// Interface for objects that track their modification time.
/// </summary>
public interface IHasModificationTime
{
    /// <summary>
    /// Gets or sets the last modification time of the entity.
    /// </summary>
    DateTime? LastModificationTime { get; set; }
}