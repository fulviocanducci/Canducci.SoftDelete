# Canducci SoftDelete Entity Framework Core

[![NuGet](https://img.shields.io/nuget/v/Canducci.SoftDelete.svg?style=plastic&label=version)](https://www.nuget.org/packages/Canducci.SoftDelete/)
[![NuGet](https://img.shields.io/nuget/dt/Canducci.SoftDelete.svg)](https://www.nuget.org/packages/Canducci.SoftDelete/)
[![.NET Core](https://github.com/fulviocanducci/Canducci.SoftDelete/workflows/.NET%20Core/badge.svg)](https://www.nuget.org/packages/Canducci.SoftDelete/)
[![Coverage Status](https://coveralls.io/repos/github/fulviocanducci/Canducci.SoftDelete/badge.svg?branch=master)](https://coveralls.io/github/fulviocanducci/Canducci.SoftDelete?branch=master)

## Package Installation (NUGET)

```Csharp

PM> Install-Package Canducci.SoftDelete

```

## How to use?

Declare o namespace `using Canducci.SoftDelete;` and implementation `class`, example:

#### - Char

```csharp
public class People: ISoftDeleteChar
{
    ...
    public char DeletedAt { get; } = 'N';
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


#### - DateTime?

```csharp
public class Animal: ISoftDeleteDateTime
{
    ...
    public DateTime? DeletedAt { get; } = null;
}
```

In the configuration em `DbContext`, configure `AddInterceptorSoftDelete` is method extension:

* `.AddInterceptorSoftDeleteChar()	     // Char`
* `.AddInterceptorSoftDeleteBool()	     // Bool`
* `.AddInterceptorSoftDeleteDateTime(); // DateTime?`

and configure `HasQueryFilterSoftDelete` is method extension:

* `options.HasQueryFilterSoftDeleteChar(); //Char`
* `options.HasQueryFilterSoftDeleteBool(); //Bool`
* `options.HasQueryFilterSoftDeleteDateTime(); //DateTime?`

### Example:

```csharp
public class DatabaseContext : DbContext
{
	public DbSet<Animal> Animal { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source = db.db", options =>
		{
		})
		.AddInterceptorSoftDeleteChar() // Char
		.AddInterceptorSoftDeleteBool()	// Bool
		.AddInterceptorSoftDeleteDateTime(); // DateTime?
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
				.HasColumnName("deleted_at")
				.HasDefaultValue(null); // Default value null
			options.HasQueryFilterSoftDeleteDateTime(); //DateTime?
		});
		modelBuilder.Entity<People>(options =>
		{
			options.ToTable("people");
			options.HasKey(x => x.Id);
			options.Property(x => x.Id)
				.HasColumnName("id");
			options.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(100);
			options.Property(x => x.DeletedAt)
				.HasColumnName("deleted_at")
				.HasDefaultValue(false); // Default value false
			options.HasQueryFilterSoftDeleteBool(); //Bool
		});
		modelBuilder.Entity<House>(options =>
		{
			options.ToTable("house");
			options.HasKey(x => x.Id);
			options.Property(x => x.Id)
				.HasColumnName("id");
			options.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired().HasMaxLength(100);
			options.Property(x => x.DeletedAt)
				.HasColumnName("deleted_at")
				.HasDefaultValue('N'); // Default value 'N'
			options.HasQueryFilterSoftDeleteChar(); //Char
		});
	}
}
```
