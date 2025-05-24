using Fermion.Domain.Shared.Abstractions;

namespace Fermion.Domain.Shared.DTOs;

[Serializable]
public abstract class AuditedEntityDto : CreationAuditedEntityDto, IAuditedObject
{
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierId { get; set; }
}

[Serializable]
public abstract class AuditedEntityDto<TKey> : CreationAuditedEntityDto<TKey>, IAuditedObject
{
    public DateTime? LastModificationTime { get; set; }
    public Guid? LastModifierId { get; set; }
}
