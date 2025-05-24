namespace Fermion.Domain.Shared.Abstractions;

public interface ICreationAuditedObject : IHasCreationTime, IMayHaveCreator
{
}