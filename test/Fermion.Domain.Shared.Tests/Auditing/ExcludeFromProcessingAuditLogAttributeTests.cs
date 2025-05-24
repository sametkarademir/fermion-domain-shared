using System.Reflection;
using Fermion.Domain.Shared.Auditing;
using Fermion.Domain.Shared.Filters;

namespace Fermion.Domain.Shared.Tests.Auditing;

public class ExcludeFromProcessingAuditLogAttributeTests
{
    [Fact]
    public void AuditProperties_ShouldHaveExcludeFromProcessingAuditLogAttribute()
    {
        // Arrange & Act
        var baseEntityProperties = typeof(Entity<string>).GetProperty("Id");
        var creationEntityProperties = new[]
        {
            typeof(CreationAuditedEntity).GetProperty("CreationTime"),
            typeof(CreationAuditedEntity).GetProperty("CreatorId")
        };
        var auditedEntityProperties = new[]
        {
            typeof(AuditedEntity).GetProperty("LastModificationTime"),
            typeof(AuditedEntity).GetProperty("LastModifierId"),
            typeof(AuditedEntity).GetProperty("ConcurrencyStamp")
        };
        var fullAuditedEntityProperties = new[]
        {
            typeof(FullAuditedEntity).GetProperty("IsDeleted"),
            typeof(FullAuditedEntity).GetProperty("DeleterId"),
            typeof(FullAuditedEntity).GetProperty("DeletionTime")
        };

        // Assert
        Assert.NotNull(baseEntityProperties?.GetCustomAttribute<ExcludeFromProcessingAuditLogAttribute>());

        foreach (var property in creationEntityProperties)
        {
            Assert.NotNull(property?.GetCustomAttribute<ExcludeFromProcessingAuditLogAttribute>());
        }

        foreach (var property in auditedEntityProperties)
        {
            Assert.NotNull(property?.GetCustomAttribute<ExcludeFromProcessingAuditLogAttribute>());
        }

        foreach (var property in fullAuditedEntityProperties)
        {
            Assert.NotNull(property?.GetCustomAttribute<ExcludeFromProcessingAuditLogAttribute>());
        }
    }

    [Fact]
    public void GenericAuditProperties_ShouldHaveExcludeFromProcessingAuditLogAttribute()
    {
        // Arrange & Act
        var creationEntityProperties = new[]
        {
            typeof(CreationAuditedEntity<int>).GetProperty("CreationTime"),
            typeof(CreationAuditedEntity<int>).GetProperty("CreatorId")
        };
        var auditedEntityProperties = new[]
        {
            typeof(AuditedEntity<int>).GetProperty("LastModificationTime"),
            typeof(AuditedEntity<int>).GetProperty("LastModifierId"),
            typeof(AuditedEntity<int>).GetProperty("ConcurrencyStamp")
        };
        var fullAuditedEntityProperties = new[]
        {
            typeof(FullAuditedEntity<int>).GetProperty("IsDeleted"),
            typeof(FullAuditedEntity<int>).GetProperty("DeleterId"),
            typeof(FullAuditedEntity<int>).GetProperty("DeletionTime")
        };

        // Assert
        foreach (var property in creationEntityProperties)
        {
            Assert.NotNull(property?.GetCustomAttribute<ExcludeFromProcessingAuditLogAttribute>());
        }

        foreach (var property in auditedEntityProperties)
        {
            Assert.NotNull(property?.GetCustomAttribute<ExcludeFromProcessingAuditLogAttribute>());
        }

        foreach (var property in fullAuditedEntityProperties)
        {
            Assert.NotNull(property?.GetCustomAttribute<ExcludeFromProcessingAuditLogAttribute>());
        }
    }
}