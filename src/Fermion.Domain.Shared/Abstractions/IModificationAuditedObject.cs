namespace Fermion.Domain.Shared.Abstractions;

public interface IModificationAuditedObject : IHasModificationTime
{
    Guid? LastModifierId { get; set; }
}