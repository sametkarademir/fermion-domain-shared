namespace Fermion.Domain.Shared.Abstractions;

public interface IHasModificationTime
{
    DateTime? LastModificationTime { get; set; }
}