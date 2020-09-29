using Canducci.SoftDelete.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Canducci.SoftDelete.Extensions
{
    public static class AddInterceptorMethodsExtensions
    {
        public static DbContextOptionsBuilder AddInterceptorSoftDeleteDateTime(this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(SoftDeleteDateTimeSaveChangesInterceptor.Create());
            return optionsBuilder;
        }
        public static DbContextOptionsBuilder AddInterceptorSoftDeleteBool(this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(SoftDeleteBoolSaveChangesInterceptor.Create());
            return optionsBuilder;
        }
    }
}
