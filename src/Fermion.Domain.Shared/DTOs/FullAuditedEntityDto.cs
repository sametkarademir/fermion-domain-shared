using Fermion.Domain.Shared.Abstractions;

namespace Fermion.Domain.Shared.DTOs;

[Serializable]
public abstract class FullAuditedEntityDto : AuditedEntityDto, IFullAuditedObject
{
    public bool IsDeleted { get; set; }
    public Guid? DeleterId { get; set; }
    public DateTime? DeletionTime { get; set; }
}

[Serializable]
public abstract class FullAuditedEntityDto<TKey> : AuditedEntityDto<TKey>, IFullAuditedObject
{
    public bool IsDeleted { get; set; }
    public Guid? DeleterId { get; set; }
    public DateTime? DeletionTime { get; set; }
}
