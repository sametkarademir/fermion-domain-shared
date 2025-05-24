using Fermion.Domain.Shared.Abstractions;

namespace Fermion.Domain.Shared.DTOs;

[Serializable]
public abstract class CreationAuditedEntityDto : EntityDto, ICreationAuditedObject
{
    public DateTime CreationTime { get; set; }
    public Guid? CreatorId { get; set; }
}

[Serializable]
public abstract class CreationAuditedEntityDto<TKey> : EntityDto<TKey>, ICreationAuditedObject
{
    public DateTime CreationTime { get; set; }
    public Guid? CreatorId { get; set; }
}
