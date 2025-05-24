using Fermion.Domain.Shared.Abstractions;

namespace Fermion.Domain.Shared.DTOs;

[Serializable]
public abstract class EntityDto : IEntityDto
{
}

[Serializable]
public abstract class EntityDto<TKey> : EntityDto, IEntityDto<TKey>
{
    public TKey Id { get; set; } = default!;
}
