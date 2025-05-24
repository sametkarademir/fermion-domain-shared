using Fermion.Domain.Shared.Auditing;

namespace Fermion.Domain.Shared.Tests.Auditing;

public class FullAuditedEntityTests
{
    [Fact]
    public void FullAuditedEntity_ShouldInheritFromAuditedEntity()
    {
        // Arrange & Act
        var entity = new TestFullAuditedEntity();

        // Assert
        Assert.IsAssignableFrom<AuditedEntity>(entity);
    }

    [Fact]
    public void FullAuditedEntity_ShouldHaveIsDeletedProperty()
    {
        // Arrange
        var entity = new TestFullAuditedEntity();

        // Act & Assert
        Assert.False(entity.IsDeleted); // Default value

        entity.IsDeleted = true;
        Assert.True(entity.IsDeleted);
    }

    [Fact]
    public void FullAuditedEntity_ShouldHaveDeleterIdProperty()
    {
        // Arrange
        var entity = new TestFullAuditedEntity();
        var testGuid = Guid.NewGuid();

        // Act
        entity.DeleterId = testGuid;

        // Assert
        Assert.Equal(testGuid, entity.DeleterId);
    }

    [Fact]
    public void FullAuditedEntity_ShouldHaveDeletionTimeProperty()
    {
        // Arrange
        var entity = new TestFullAuditedEntity();
        var testTime = new DateTime(2023, 1, 1);

        // Act
        entity.DeletionTime = testTime;

        // Assert
        Assert.Equal(testTime, entity.DeletionTime);
    }

    [Fact]
    public void FullAuditedEntityWithKey_ShouldInheritFromAuditedEntityWithKey()
    {
        // Arrange & Act
        var entity = new TestFullAuditedEntityWithKey<int>();

        // Assert
        Assert.IsAssignableFrom<AuditedEntity<int>>(entity);
    }

    [Fact]
    public void FullAuditedEntityWithKey_WithoutId_ShouldSetDefaultId()
    {
        // Arrange & Act
        var entity = new TestFullAuditedEntityWithKey<int>();

        // Assert
        Assert.Equal(0, entity.Id);
    }

    [Fact]
    public void FullAuditedEntityWithKey_WithId_ShouldSetProvidedId()
    {
        // Arrange & Act
        var entity = new TestFullAuditedEntityWithKey<int>(42);

        // Assert
        Assert.Equal(42, entity.Id);
    }

    [Fact]
    public void FullAuditedEntityWithKey_ShouldHaveAllAuditProperties()
    {
        // Arrange
        var entity = new TestFullAuditedEntityWithKey<int>(42);
        var creationTime = new DateTime(2023, 1, 1);
        var creatorId = Guid.NewGuid();
        var modificationTime = new DateTime(2023, 1, 2);
        var modifierId = Guid.NewGuid();
        var deletionTime = new DateTime(2023, 1, 3);
        var deleterId = Guid.NewGuid();

        // Act
        entity.CreationTime = creationTime;
        entity.CreatorId = creatorId;
        entity.LastModificationTime = modificationTime;
        entity.LastModifierId = modifierId;
        entity.DeletionTime = deletionTime;
        entity.DeleterId = deleterId;
        entity.IsDeleted = true;

        // Assert
        Assert.Equal(creationTime, entity.CreationTime);
        Assert.Equal(creatorId, entity.CreatorId);
        Assert.Equal(modificationTime, entity.LastModificationTime);
        Assert.Equal(modifierId, entity.LastModifierId);
        Assert.Equal(deletionTime, entity.DeletionTime);
        Assert.Equal(deleterId, entity.DeleterId);
        Assert.True(entity.IsDeleted);
        Assert.NotNull(entity.ConcurrencyStamp);
    }

    // Test implementation classes
    private class TestFullAuditedEntity : FullAuditedEntity
    {
    }

    private class TestFullAuditedEntityWithKey<TKey> : FullAuditedEntity<TKey>
    {
        public TestFullAuditedEntityWithKey()
        {
        }

        public TestFullAuditedEntityWithKey(TKey id) : base(id)
        {
        }
    }
}