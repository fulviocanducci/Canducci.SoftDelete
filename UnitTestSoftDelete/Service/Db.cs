using Canducci.SoftDelete.Extensions;
using Microsoft.EntityFrameworkCore;
using UnitTestSoftDelete.Models;

namespace UnitTestSoftDelete.Service
{
    public sealed class Db : DbContext
    {
        public DbSet<ModelBool> ModelBools { get; set; }
        public DbSet<ModelChar> ModelChars { get; set; }
        public DbSet<ModelDateTime> ModelDateTimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DatabaseNew")
                .AddInterceptorSoftDeleteBool()
                .AddInterceptorSoftDeleteChar()
                .AddInterceptorSoftDeleteDateTime();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelBool>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id);
                x.Property(x => x.DeletedAt);
                x.HasQueryFilterSoftDeleteBool();
            });
            modelBuilder.Entity<ModelChar>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id);
                x.Property(x => x.DeletedAt);
                x.HasQueryFilterSoftDeleteChar();
            });
            modelBuilder.Entity<ModelDateTime>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Id);
                x.Property(x => x.DeletedAt);
                x.HasQueryFilterSoftDeleteDateTime();
            });
        }
    }
}
