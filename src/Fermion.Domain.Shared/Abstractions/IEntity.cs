namespace Fermion.Domain.Shared.Abstractions;

public interface IEntity
{
}

public interface IEntity<TKey> : IEntity
{
    TKey Id { get; }
}