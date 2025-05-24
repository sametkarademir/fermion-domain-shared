namespace Fermion.Domain.Shared.Abstractions;

public interface IHasConcurrencyStamp
{
    string ConcurrencyStamp { get; set; }
}