using Fermion.Domain.Shared.Abstractions;
using Fermion.Domain.Shared.Filters;

namespace Fermion.Domain.Shared.Auditing;

[Serializable]
public abstract class Entity : IEntity
{
    protected Entity()
    {
    }
}

[Serializable]
public abstract class Entity<TKey> : Entity, IEntity<TKey>
{
    [ExcludeFromProcessing]
    public virtual TKey Id { get; set; } = default!;

    protected Entity()
    {
    }

    protected Entity(TKey id)
    {
        Id = id;
    }
}