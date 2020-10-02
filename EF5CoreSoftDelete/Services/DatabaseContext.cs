using Canducci.SoftDelete.Extensions;
using EF5CoreSoftDelete.Models;
using Microsoft.EntityFrameworkCore;

namespace EF5CoreSoftDelete.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Animal> Animal { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<House> House { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = db.db", options =>
            {
            })
            .AddInterceptorSoftDeleteChar()
            .AddInterceptorSoftDeleteBool()
            .AddInterceptorSoftDeleteDateTime();
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
                    .HasDefaultValue(null);
                options.HasQueryFilterSoftDeleteDateTime();
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
                    .HasDefaultValue(false);
                options.HasQueryFilterSoftDeleteBool();
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
                    .HasDefaultValue('N');
                options.HasQueryFilterSoftDeleteChar();
            });
        }
    }
}
