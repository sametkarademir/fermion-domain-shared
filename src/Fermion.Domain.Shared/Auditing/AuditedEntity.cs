using Fermion.Domain.Shared.Abstractions;
using Fermion.Domain.Shared.Filters;

namespace Fermion.Domain.Shared.Auditing;

[Serializable]
public abstract class AuditedEntity : CreationAuditedEntity, IAuditedObject, IHasConcurrencyStamp
{
    [ExcludeFromProcessingAuditLog]
    public virtual DateTime? LastModificationTime { get; set; }
    [ExcludeFromProcessingAuditLog]
    public virtual Guid? LastModifierId { get; set; }
    [ExcludeFromProcessingAuditLog]
    public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString("N");
}

[Serializable]
public abstract class AuditedEntity<TKey> : CreationAuditedEntity<TKey>, IAuditedObject, IHasConcurrencyStamp
{
    [ExcludeFromProcessingAuditLog]
    public virtual DateTime? LastModificationTime { get; set; }
    [ExcludeFromProcessingAuditLog]
    public virtual Guid? LastModifierId { get; set; }
    [ExcludeFromProcessingAuditLog]
    public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString("N");

    protected AuditedEntity()
    {

    }

    protected AuditedEntity(TKey id) : base(id)
    {

    }
}