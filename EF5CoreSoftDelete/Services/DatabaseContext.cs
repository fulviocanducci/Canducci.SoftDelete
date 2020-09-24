using Canducci.SoftDelete;
using EF5CoreSoftDelete.Models;
using Microsoft.EntityFrameworkCore;

namespace EF5CoreSoftDelete.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Animal> Animal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = db.db", options =>
            {
            })
            .AddInterceptorSoftDelete();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(options =>
            {
                options.ToTable("animal");
                options.HasKey(x => x.Id);
                options.Property(x => x.Id).HasColumnName("id");
                options.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
                options.Property(x => x.DeletedAt).HasColumnName("deleted_at");
                options.HasQueryFilter(x => x.DeletedAt == null);
            });
        }
    }
}
