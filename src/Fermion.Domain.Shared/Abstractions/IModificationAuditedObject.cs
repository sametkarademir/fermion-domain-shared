namespace Fermion.Domain.Shared.Abstractions;

/// <summary>
/// Interface for objects that track modification information.
/// </summary>
public interface IModificationAuditedObject : IHasModificationTime
{
    /// <summary>
    /// Gets or sets the unique identifier of the user who last modified the entity.
    /// </summary>
    Guid? LastModifierId { get; set; }
}