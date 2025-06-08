namespace Fermion.Domain.Shared.Abstractions;

/// <summary>
/// Interface for audited objects that track creation and modification information.
/// Combines creation and modification audit interfaces.
/// </summary>
public interface IAuditedObject :
    ICreationAuditedObject,
    IHasCreationTime,
    IMayHaveCreator,
    IModificationAuditedObject,
    IHasModificationTime
{
}