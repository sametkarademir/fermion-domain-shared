namespace Fermion.Domain.Shared.Abstractions;

public interface IEntityCorrelationId
{
    Guid? CorrelationId { get; set; }
}