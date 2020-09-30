# Canducci SoftDelete Entity Framework Core 5

[![NuGet](https://img.shields.io/nuget/v/Canducci.SoftDelete.svg?style=plastic&label=version)](https://www.nuget.org/packages/Canducci.SoftDelete/)
[![NuGet](https://img.shields.io/nuget/dt/Canducci.SoftDelete.svg)](https://www.nuget.org/packages/Canducci.SoftDelete/)

## Package Installation (NUGET)

```Csharp

PM> Install-Package Canducci.SoftDelete

```

## How to use?

Declare o namespace `using Canducci.SoftDelete;` and implementation `class`, example:

#### - DateTime?

```csharp
public class Animal: ISoftDeleteDateTime
{
    ...
    public DateTime? DeletedAt { get; } = null;
}
```

#### - Bool

```csharp
public class People: ISoftDeleteBool
{
    ...
    public bool DeletedAt { get; } = false;
}
```

In the configuration em `DbContext`, configure `AddInterceptorSoftDelete` is method extesion and configure `HasQueryFilter(x => x.DeletedAt == null)`, example:

```csharp
public class DatabaseContext : DbContext
{
	public DbSet<Animal> Animal { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source = db.db", options =>
		{
		})
		.AddInterceptorSoftDeleteDateTime() // DateTime?
		.AddInterceptorSoftDeleteBool(); // Boolean 
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Animal>(options =>
		{
			options.ToTable("animal");
			options.HasKey(x => x.Id);
			options.Property(x => x.Id)
				.HasColumnName("id");
			options.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(100);
			options.Property(x => x.DeletedAt)
				.HasColumnName("deleted_at");
			options.HasQueryFilterSoftDeleteDateTime();	// DateTime?
		});
		modelBuilder.Entity<People>(options =>
		{
			options.ToTable("people");
			options.HasKey(x => x.Id);
			options.Property(x => x.Id).HasColumnName("id");
			options.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
			options.Property(x => x.DeletedAt).HasColumnName("deleted_at").HasDefaultValue(false);
			options.HasQueryFilterSoftDeleteBool(); // Bool
		});
	}
}
```
