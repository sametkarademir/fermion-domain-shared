namespace Fermion.Domain.Shared.Abstractions;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}