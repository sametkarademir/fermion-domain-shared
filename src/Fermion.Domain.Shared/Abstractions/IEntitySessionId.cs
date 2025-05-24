namespace Fermion.Domain.Shared.Abstractions;

public interface IEntitySessionId
{
    Guid? SessionId { get; set; }
}