namespace Fermion.Domain.Shared.Abstractions;

public interface IMayHaveCreator
{
    Guid? CreatorId { get; set; }
}