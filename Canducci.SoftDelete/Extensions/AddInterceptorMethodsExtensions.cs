using Canducci.SoftDelete.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Canducci.SoftDelete.Extensions
{
    public static class AddInterceptorMethodsExtensions
    {
        public static DbContextOptionsBuilder AddInterceptorSoftDeleteDateTime(
            this DbContextOptionsBuilder optionsBuilder
        )
        {
            return optionsBuilder
                .AddInterceptors(SoftDeleteDateTimeSaveChangesInterceptor.Create());            
        }
        public static DbContextOptionsBuilder AddInterceptorSoftDeleteBool(
            this DbContextOptionsBuilder optionsBuilder
        )
        {
            return optionsBuilder
                .AddInterceptors(SoftDeleteBoolSaveChangesInterceptor.Create());
        }
    }
}
