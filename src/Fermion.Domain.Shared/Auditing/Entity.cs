using Fermion.Domain.Shared.Abstractions;
using Fermion.Domain.Shared.Filters;

namespace Fermion.Domain.Shared.Auditing;

[Serializable]
public abstract class Entity : IEntity
{
    protected Entity()
    {
    }

    private Dictionary<string, object?> _originalValues = new();

    public void TrackChanges()
    {
        _originalValues.Clear();
        foreach (var property in GetType().GetProperties().Where(p => p.CanRead))
        {
            _originalValues[property.Name] = property.GetValue(this);
        }
    }

    public Dictionary<string, (object Original, object Current)> GetChanges()
    {
        var changes = new Dictionary<string, (object, object)>();
        foreach (var kvp in _originalValues)
        {
            var currentValue = GetType().GetProperty(kvp.Key)?.GetValue(this);
            if (!Equals(kvp.Value, currentValue))
            {
                changes[kvp.Key] = (kvp.Value, currentValue)!;
            }
        }
        return changes;
    }
}

[Serializable]
public abstract class Entity<TKey> : Entity, IEntity<TKey>
{
    [ExcludeFromProcessingAuditLog]
    public virtual TKey Id { get; set; } = default!;

    protected Entity()
    {
    }

    protected Entity(TKey id)
    {
        Id = id;
    }
}