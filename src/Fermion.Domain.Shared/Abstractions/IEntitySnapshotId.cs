namespace Fermion.Domain.Shared.Abstractions;

public interface IEntitySnapshotId
{
    Guid? SnapshotId { get; set; }
}