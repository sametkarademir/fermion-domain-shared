using Fermion.Domain.Shared.Abstractions;
using Fermion.Domain.Shared.Filters;

namespace Fermion.Domain.Shared.Auditing;

[Serializable]
public abstract class CreationAuditedEntity : Entity, ICreationAuditedObject
{
    [ExcludeFromProcessing]
    public virtual DateTime CreationTime { get; set; }
    [ExcludeFromProcessing]
    public virtual Guid? CreatorId { get; set; }
}

[Serializable]
public abstract class CreationAuditedEntity<TKey> : Entity<TKey>, ICreationAuditedObject
{
    [ExcludeFromProcessing]
    public virtual DateTime CreationTime { get; set; }
    [ExcludeFromProcessing]
    public virtual Guid? CreatorId { get; set; }

    protected CreationAuditedEntity()
    {

    }

    protected CreationAuditedEntity(TKey id) : base(id)
    {

    }
}