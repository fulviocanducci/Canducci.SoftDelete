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
                .AddInterceptors(new SoftDeleteDateTimeSaveChangesInterceptor());
        }
        public static DbContextOptionsBuilder AddInterceptorSoftDeleteBool(
            this DbContextOptionsBuilder optionsBuilder
        )
        {
            return optionsBuilder
                .AddInterceptors(new SoftDeleteBoolSaveChangesInterceptor());
        }

        public static DbContextOptionsBuilder AddInterceptorSoftDeleteChar(
            this DbContextOptionsBuilder optionsBuilder
        )
        {
            return optionsBuilder
                .AddInterceptors(new SoftDeleteCharSaveChangesInterceptor());
        }
    }
}
