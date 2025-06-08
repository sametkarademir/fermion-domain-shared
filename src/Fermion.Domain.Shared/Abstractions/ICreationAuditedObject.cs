namespace Fermion.Domain.Shared.Abstractions;

/// <summary>
/// Interface for objects that track creation information.
/// Combines creation time and creator interfaces.
/// </summary>
public interface ICreationAuditedObject : IHasCreationTime, IMayHaveCreator
{
}