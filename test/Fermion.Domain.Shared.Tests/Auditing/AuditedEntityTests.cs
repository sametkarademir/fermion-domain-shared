using Fermion.Domain.Shared.Auditing;

namespace Fermion.Domain.Shared.Tests.Auditing;

public class AuditedEntityTests
{
    [Fact]
    public void AuditedEntity_ShouldInheritFromCreationAuditedEntity()
    {
        // Arrange & Act
        var entity = new TestAuditedEntity();

        // Assert
        Assert.IsAssignableFrom<CreationAuditedEntity>(entity);
    }

    [Fact]
    public void AuditedEntity_ShouldHaveLastModificationTimeProperty()
    {
        // Arrange
        var entity = new TestAuditedEntity();
        var testTime = new DateTime(2023, 1, 1);

        // Act
        entity.LastModificationTime = testTime;

        // Assert
        Assert.Equal(testTime, entity.LastModificationTime);
    }

    [Fact]
    public void AuditedEntity_ShouldHaveLastModifierIdProperty()
    {
        // Arrange
        var entity = new TestAuditedEntity();
        var testGuid = Guid.NewGuid();

        // Act
        entity.LastModifierId = testGuid;

        // Assert
        Assert.Equal(testGuid, entity.LastModifierId);
    }

    [Fact]
    public void AuditedEntity_ShouldGenerateConcurrencyStamp()
    {
        // Arrange & Act
        var entity = new TestAuditedEntity();

        // Assert
        Assert.NotNull(entity.ConcurrencyStamp);
        Assert.NotEmpty(entity.ConcurrencyStamp);
        Assert.Equal(32, entity.ConcurrencyStamp.Length); // Format "N" results in 32 chars
    }

    [Fact]
    public void AuditedEntityWithKey_ShouldInheritFromCreationAuditedEntityWithKey()
    {
        // Arrange & Act
        var entity = new TestAuditedEntityWithKey<int>();

        // Assert
        Assert.IsAssignableFrom<CreationAuditedEntity<int>>(entity);
    }

    [Fact]
    public void AuditedEntityWithKey_WithoutId_ShouldSetDefaultId()
    {
        // Arrange & Act
        var entity = new TestAuditedEntityWithKey<int>();

        // Assert
        Assert.Equal(0, entity.Id);
    }

    [Fact]
    public void AuditedEntityWithKey_WithId_ShouldSetProvidedId()
    {
        // Arrange & Act
        var entity = new TestAuditedEntityWithKey<int>(42);

        // Assert
        Assert.Equal(42, entity.Id);
    }

    [Fact]
    public void AuditedEntityWithKey_ShouldHaveAuditProperties()
    {
        // Arrange
        var entity = new TestAuditedEntityWithKey<int>(42);
        var testCreationTime = new DateTime(2023, 1, 1);
        var testCreatorId = Guid.NewGuid();
        var testModificationTime = new DateTime(2023, 1, 2);
        var testModifierId = Guid.NewGuid();

        // Act
        entity.CreationTime = testCreationTime;
        entity.CreatorId = testCreatorId;
        entity.LastModificationTime = testModificationTime;
        entity.LastModifierId = testModifierId;

        // Assert
        Assert.Equal(testCreationTime, entity.CreationTime);
        Assert.Equal(testCreatorId, entity.CreatorId);
        Assert.Equal(testModificationTime, entity.LastModificationTime);
        Assert.Equal(testModifierId, entity.LastModifierId);
        Assert.NotNull(entity.ConcurrencyStamp);
    }

    [Fact]
    public void AuditedEntityWithKey_ShouldAllowChangingConcurrencyStamp()
    {
        // Arrange
        var entity = new TestAuditedEntityWithKey<int>(42);
        var originalStamp = entity.ConcurrencyStamp;
        var newStamp = Guid.NewGuid().ToString("N");

        // Act
        entity.ConcurrencyStamp = newStamp;

        // Assert
        Assert.NotEqual(originalStamp, entity.ConcurrencyStamp);
        Assert.Equal(newStamp, entity.ConcurrencyStamp);
    }

    // Test implementation classes
    private class TestAuditedEntity : AuditedEntity
    {
    }

    private class TestAuditedEntityWithKey<TKey> : AuditedEntity<TKey>
    {
        public TestAuditedEntityWithKey()
        {
        }

        public TestAuditedEntityWithKey(TKey id) : base(id)
        {
        }
    }
}