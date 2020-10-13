using Canducci.SoftDelete.Internals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Canducci.SoftDelete.Interceptors
{
    public class SoftDeleteDateTimeSaveChangesInterceptor : SaveChangesInterceptor
    {
        private Entries<ISoftDeleteDateTime> Entries { get; }
        private void SoftDelete(DbContextEventData eventData)
        {
            List<EntityEntry> entityEntries = Entries.GetEntityEntries(eventData);
            if (entityEntries.Any())
            {
                DateTime actual = DateTime.Now;
                foreach (var entity in entityEntries)
                {
                    entity.Property("DeletedAt").CurrentValue = actual;
                    entity.State = EntityState.Modified;
                }
            }
        }

        public SoftDeleteDateTimeSaveChangesInterceptor()
        {
            Entries = new EntriesSoftDeleteDateTime();
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
