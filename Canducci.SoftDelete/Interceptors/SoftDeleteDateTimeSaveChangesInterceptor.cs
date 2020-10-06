using Canducci.SoftDelete.Internals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Canducci.SoftDelete.Interceptors
{
    public class SoftDeleteDateTimeSaveChangesInterceptor : SaveChangesInterceptor
    {
        internal void SoftDelete(DbContextEventData eventData)
        {
            Entries<ISoftDeleteDateTime> entityEntries = new Entries<ISoftDeleteDateTime>(eventData);
            if (entityEntries.Any())
            {
                DateTime now = DateTime.Now;
                foreach (var entity in entityEntries)
                {
                    entity.Property("DeletedAt").CurrentValue = now;
                    entity.State = EntityState.Modified;
                }
            }
        }

        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result
        )
        {
            SoftDelete(eventData);
            return result;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            SoftDelete(eventData);
            return new ValueTask<InterceptionResult<int>>(result);
        }
    }
}
