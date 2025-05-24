using Fermion.Domain.Shared.Abstractions;
using Fermion.Domain.Shared.Filters;

namespace Fermion.Domain.Shared.Auditing;

[Serializable]
public abstract class FullAuditedEntity : AuditedEntity, IFullAuditedObject
{
    [ExcludeFromProcessing]
    public virtual bool IsDeleted { get; set; }
    [ExcludeFromProcessing]
    public virtual Guid? DeleterId { get; set; }
    [ExcludeFromProcessing]
    public virtual DateTime? DeletionTime { get; set; }
}

[Serializable]
public abstract class FullAuditedEntity<TKey> : AuditedEntity<TKey>, IFullAuditedObject
{
    [ExcludeFromProcessing]
    public virtual bool IsDeleted { get; set; }
    [ExcludeFromProcessing]
    public virtual Guid? DeleterId { get; set; }
    [ExcludeFromProcessing]
    public virtual DateTime? DeletionTime { get; set; }

    protected FullAuditedEntity()
    {

    }

    protected FullAuditedEntity(TKey id) : base(id)
    {

    }
}