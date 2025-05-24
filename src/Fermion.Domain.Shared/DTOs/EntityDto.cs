using Fermion.Domain.Shared.Abstractions;

namespace Fermion.Domain.Shared.DTOs;

[Serializable]
public abstract class EntityDto : IEntityDto
{
    public override string ToString()
    {
        return $"[DTO: {GetType().Name}]";
    }
}

[Serializable]
public abstract class EntityDto<TKey> : EntityDto, IEntityDto<TKey>
{
    public TKey Id { get; set; } = default!;

    public override string ToString()
    {
        if (EqualityComparer<TKey>.Default.Equals(Id, default!))
        {
            return $"[DTO: {GetType().Name}]";
        }

        return $"[DTO: {GetType().Name}] Id = {Id}";
    }
}
