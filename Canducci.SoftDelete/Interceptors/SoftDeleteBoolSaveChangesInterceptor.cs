using Canducci.SoftDelete.Internals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Canducci.SoftDelete.Interceptors
{
    public class SoftDeleteBoolSaveChangesInterceptor : SaveChangesInterceptor
    {
        internal void SoftDelete(DbContextEventData eventData)
        {
            Entries<ISoftDeleteBool> entityEntries = new Entries<ISoftDeleteBool>(eventData);
            if (entityEntries.Any())
            {
                foreach (var entity in entityEntries)
                {
                    entity.Property("DeletedAt").CurrentValue = true;
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
