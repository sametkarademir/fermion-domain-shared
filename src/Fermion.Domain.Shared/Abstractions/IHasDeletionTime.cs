namespace Fermion.Domain.Shared.Abstractions;

public interface IHasDeletionTime : ISoftDelete
{
    DateTime? DeletionTime { get; set; }
}