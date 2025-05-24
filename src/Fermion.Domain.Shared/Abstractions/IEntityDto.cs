namespace Fermion.Domain.Shared.Abstractions;

public interface IEntityDto
{
}

public interface IEntityDto<TKey> : IEntityDto
{
    TKey Id { get; set; }
}