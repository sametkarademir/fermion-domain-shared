namespace Fermion.Domain.Shared.Abstractions;

/// <summary>
/// Interface for objects that may have a creator user.
/// </summary>
public interface IMayHaveCreator
{
    /// <summary>
    /// Gets or sets the unique identifier of the user who created the entity.
    /// </summary>
    Guid? CreatorId { get; set; }
}