namespace Fermion.Domain.Shared.Abstractions;

public interface IDeletionAuditedObject : IHasDeletionTime, ISoftDelete
{
    Guid? DeleterId { get; set; }
}