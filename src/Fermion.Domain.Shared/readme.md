# Fermion.Domain.Shared

A comprehensive library that provides common abstractions, base classes, and utilities for domain-driven design in .NET applications.

## Features

- **Entity Base Classes**: Provides base classes for entities with common properties like Id, CreationTime, etc.
- **Audit Support**: Built-in support for auditing with creation and modification tracking.
- **Filtering**: Flexible filtering capabilities for entities.
- **Conventions**: Common conventions for entity configuration.
- **DTOs**: Base classes for Data Transfer Objects with audit support.

## Installation

```bash
dotnet add package Fermion.Domain.Shared
```

## Usage

### Entity Base Classes

```csharp
public class Product : Entity<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### Audit Support

```csharp
public class Order : AuditedEntity<Guid>
{
    public string OrderNumber { get; set; }
    public decimal TotalAmount { get; set; }
}
```

### Filtering

```csharp
public class ProductFilter : EntityFilter
{
    public string Name { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.