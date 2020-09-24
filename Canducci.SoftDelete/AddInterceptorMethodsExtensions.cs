using Microsoft.EntityFrameworkCore;

namespace Canducci.SoftDelete
{
    public static class AddInterceptorMethodsExtensions
    {
        public static DbContextOptionsBuilder AddInterceptorSoftDelete(this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(SoftDeleteSaveChangesInterceptor.Create());
            return optionsBuilder;
        }
    }
}
