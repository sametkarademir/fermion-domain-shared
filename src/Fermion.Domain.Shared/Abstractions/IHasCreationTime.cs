namespace Fermion.Domain.Shared.Abstractions;

public interface IHasCreationTime
{
    DateTime CreationTime { get; set; }
}