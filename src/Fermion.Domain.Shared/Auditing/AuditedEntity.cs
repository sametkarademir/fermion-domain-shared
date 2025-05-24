using Fermion.Domain.Shared.Abstractions;
using Fermion.Domain.Shared.Filters;

namespace Fermion.Domain.Shared.Auditing;

[Serializable]
public abstract class AuditedEntity : CreationAuditedEntity, IAuditedObject, IHasConcurrencyStamp
{
    [ExcludeFromProcessing]
    public virtual DateTime? LastModificationTime { get; set; }
    [ExcludeFromProcessing]
    public virtual Guid? LastModifierId { get; set; }
    [ExcludeFromProcessing]
    public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString("N");
}

[Serializable]
public abstract class AuditedEntity<TKey> : CreationAuditedEntity<TKey>, IAuditedObject, IHasConcurrencyStamp
{
    [ExcludeFromProcessing]
    public virtual DateTime? LastModificationTime { get; set; }
    [ExcludeFromProcessing]
    public virtual Guid? LastModifierId { get; set; }
    [ExcludeFromProcessing]
    public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString("N");

    protected AuditedEntity()
    {

    }

    protected AuditedEntity(TKey id) : base(id)
    {

    }
}