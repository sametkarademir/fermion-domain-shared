using Fermion.Domain.Shared.Abstractions;
using Fermion.Domain.Shared.Filters;

namespace Fermion.Domain.Shared.Auditing;

[Serializable]
public abstract class FullAuditedEntity : AuditedEntity, IFullAuditedObject
{
    [ExcludeFromProcessingAuditLog]
    public virtual bool IsDeleted { get; set; }
    [ExcludeFromProcessingAuditLog]
    public virtual Guid? DeleterId { get; set; }
    [ExcludeFromProcessingAuditLog]
    public virtual DateTime? DeletionTime { get; set; }
}

[Serializable]
public abstract class FullAuditedEntity<TKey> : AuditedEntity<TKey>, IFullAuditedObject
{
    [ExcludeFromProcessingAuditLog]
    public virtual bool IsDeleted { get; set; }
    [ExcludeFromProcessingAuditLog]
    public virtual Guid? DeleterId { get; set; }
    [ExcludeFromProcessingAuditLog]
    public virtual DateTime? DeletionTime { get; set; }

    protected FullAuditedEntity()
    {

    }

    protected FullAuditedEntity(TKey id) : base(id)
    {

    }
}