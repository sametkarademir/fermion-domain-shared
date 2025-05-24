# Fermion.Domain.Shared

Fermion.Domain.Shared is a library that provides common abstractions, base classes, and utilities for domain-driven design in .NET applications.

## Features

- Base entity classes
- DTO base classes
- Controller conventions
- API filters
- Domain abstractions

## Installation

```bash
   dotnet add package Fermion.Domain.Shared
```

## Content

### Domain Abstractions

#### Core Interfaces
- `IEntity<TKey>`: Base interface for all entities
  - Id property
  - Equality comparison
  - Type information

- `IAuditedObject`: Interface for audited entities
  - Creation time
  - Creator ID
  - Last modification time
  - Last modifier ID

- `IFullAuditedObject`: Interface for fully audited entities
  - Creation audit
  - Modification audit
  - Deletion audit
  - Soft delete support

- `ISoftDelete`: Interface for soft deletable entities
  - IsDeleted flag
  - Deletion time

### Base Entity Classes

#### Core Entities
- `Entity<TKey>`: Base class for all entities
  - Id property
  - Equality implementation
  - Type information
  - Concurrency stamp

- `AuditedEntity<TKey>`: Base class for audited entities
  - Creation time
  - Creator ID
  - Last modification time
  - Last modifier ID

- `FullAuditedEntity<TKey>`: Base class for fully audited entities
  - Creation audit
  - Modification audit
  - Deletion audit
  - Soft delete support

### DTO Base Classes

#### Core DTOs
- `EntityDto<TKey>`: Base class for entity DTOs
  - Id property
  - Type information
  - Mapping support

- `AuditedEntityDto<TKey>`: Base class for audited entity DTOs
  - Creation time
  - Creator ID
  - Last modification time
  - Last modifier ID

- `FullAuditedEntityDto<TKey>`: Base class for fully audited entity DTOs
  - Creation audit
  - Modification audit
  - Deletion audit
  - Soft delete information

### Controller Conventions

#### Authorization Convention
- `ControllerAuthorizationConvention`: Convention for controller authorization
  - Global policy application
  - Role-based authorization
  - Authentication requirement
  - Route prefix configuration

#### Disabling Convention
- `ControllerDisablingConvention`: Convention for disabling controllers
  - API endpoint disabling
  - Controller disabling
  - Route disabling

### API Filters

#### Core Filters
- `DisableApiFilter`: Filter for disabling API endpoints
  - Endpoint disabling
  - Response modification
  - Status code configuration

## Usage

### Entity Implementation

```csharp
public class User : FullAuditedEntity<Guid>
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    protected User() { }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}
```

### DTO Implementation

```csharp
public class UserDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public string LastModifiedBy { get; set; }
}
```

### Controller Convention Usage

```csharp
services.AddControllers()
    .AddMvcOptions(options =>
    {
        options.Conventions.Add(new ControllerAuthorizationConvention(
            typeof(UserController),
            "api/users",
            requireAuthentication: true,
            globalPolicy: "RequireAdminRole"
        ));
    });
```

## Features

- Audit logging integration
- Soft delete implementation
- Controller conventions
- API filtering
- Type safety
- Concurrency control