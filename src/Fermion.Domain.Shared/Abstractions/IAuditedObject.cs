namespace Fermion.Domain.Shared.Abstractions;

public interface IAuditedObject :
    ICreationAuditedObject,
    IHasCreationTime,
    IMayHaveCreator,
    IModificationAuditedObject,
    IHasModificationTime
{
}