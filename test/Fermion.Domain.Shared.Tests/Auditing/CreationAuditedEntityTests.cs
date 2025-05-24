using Fermion.Domain.Shared.Auditing;

namespace Fermion.Domain.Shared.Tests.Auditing;

public class CreationAuditedEntityTests
{
    [Fact]
    public void CreationAuditedEntity_ShouldInheritFromEntity()
    {
        // Arrange & Act
        var entity = new TestCreationAuditedEntity();

        // Assert
        Assert.IsAssignableFrom<Entity>(entity);
    }

    [Fact]
    public void CreationAuditedEntity_ShouldHaveCreationTimeProperty()
    {
        // Arrange
        var entity = new TestCreationAuditedEntity();
        var testTime = new DateTime(2023, 1, 1);

        // Act
        entity.CreationTime = testTime;

        // Assert
        Assert.Equal(testTime, entity.CreationTime);
    }

    [Fact]
    public void CreationAuditedEntity_ShouldHaveCreatorIdProperty()
    {
        // Arrange
        var entity = new TestCreationAuditedEntity();
        var testGuid = Guid.NewGuid();

        // Act
        entity.CreatorId = testGuid;

        // Assert
        Assert.Equal(testGuid, entity.CreatorId);
    }

    [Fact]
    public void CreationAuditedEntityWithKey_ShouldInheritFromEntityWithKey()
    {
        // Arrange & Act
        var entity = new TestCreationAuditedEntityWithKey<int>();

        // Assert
        Assert.IsAssignableFrom<Entity<int>>(entity);
    }

    [Fact]
    public void CreationAuditedEntityWithKey_WithoutId_ShouldSetDefaultId()
    {
        // Arrange & Act
        var entity = new TestCreationAuditedEntityWithKey<int>();

        // Assert
        Assert.Equal(0, entity.Id);
    }

    [Fact]
    public void CreationAuditedEntityWithKey_WithId_ShouldSetProvidedId()
    {
        // Arrange & Act
        var entity = new TestCreationAuditedEntityWithKey<int>(42);

        // Assert
        Assert.Equal(42, entity.Id);
    }

    [Fact]
    public void CreationAuditedEntityWithKey_ShouldHaveCreationProperties()
    {
        // Arrange
        var entity = new TestCreationAuditedEntityWithKey<int>(42);
        var testTime = new DateTime(2023, 1, 1);
        var testGuid = Guid.NewGuid();

        // Act
        entity.CreationTime = testTime;
        entity.CreatorId = testGuid;

        // Assert
        Assert.Equal(testTime, entity.CreationTime);
        Assert.Equal(testGuid, entity.CreatorId);
    }

    // Test implementation classes
    private class TestCreationAuditedEntity : CreationAuditedEntity
    {
    }

    private class TestCreationAuditedEntityWithKey<TKey> : CreationAuditedEntity<TKey>
    {
        public TestCreationAuditedEntityWithKey()
        {
        }

        public TestCreationAuditedEntityWithKey(TKey id) : base(id)
        {
        }
    }
}