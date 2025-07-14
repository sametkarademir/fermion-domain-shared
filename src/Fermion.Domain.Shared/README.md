# Fermion.Domain.Shared

Fermion.Domain.Shared is a comprehensive library that provides common abstractions, base classes, and utilities to facilitate domain-driven design (DDD) in .NET applications.

## Features

- **Entity Base Classes:** Base classes for entities with common properties such as Id, CreationTime, etc.
- **Audited Entities:** Built-in support for auditing, including creation, modification, and deletion tracking.
- **DTO Base Classes:** Base classes for Data Transfer Objects with audit support.
- **Filters and Attributes:** Flexible filters such as disabling APIs or excluding properties from processing.
- **Controller Conventions:** Conventions for controller-level authorization, disabling, and removal.

## Installation

```bash
  dotnet add package Fermion.Domain.Shared
```

## Basic Usage

### 1. Entity Base Classes

```csharp
using Fermion.Domain.Shared.Auditing;

public class Product : FullAuditedEntity<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### 2. DTO Base Classes

```csharp
using Fermion.Domain.Shared.DTOs;

public class ProductDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### 3. Disabling an API

To disable a controller or action:

```csharp
using Fermion.Domain.Shared.Filters;

[DisableApiFilter]
public class LegacyController : ControllerBase
{
    // All requests will return 404
}
```

### 4. Controller Conventions

To add authorization or disabling conventions to controllers:

```csharp
using Fermion.Domain.Shared.Conventions;

// In Startup or Program.cs
options.Conventions.Add(new ControllerDisablingConvention(typeof(LegacyController)));
```