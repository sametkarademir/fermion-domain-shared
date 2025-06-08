namespace Fermion.Domain.Shared.Abstractions;

/// <summary>
/// Interface for fully audited objects that track creation, modification, and deletion information.
/// Combines all audit interfaces for complete entity tracking.
/// </summary>
public interface IFullAuditedObject :
    IAuditedObject,
    ICreationAuditedObject,
    IHasCreationTime,
    IMayHaveCreator,
    IModificationAuditedObject,
    IHasModificationTime,
    IDeletionAuditedObject,
    IHasDeletionTime,
    ISoftDelete
{
}