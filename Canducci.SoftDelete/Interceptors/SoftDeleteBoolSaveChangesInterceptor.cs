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
    public class SoftDeleteBoolSaveChangesInterceptor : SaveChangesInterceptor
    {
        internal bool Wheres(EntityEntry where)
        {
            return where.State == EntityState.Deleted &&
                    where.Entity.GetType().GetInterfaces()
                        .Contains(typeof(ISoftDeleteBool));
        }

        internal List<EntityEntry> GetEntityEntries(DbContextEventData eventData)
        {
            return eventData.Context.ChangeTracker.Entries().Where(Wheres).ToList();
        }

        internal void SoftDelete(DbContextEventData eventData)
        {
            IList<EntityEntry> entityEntries = GetEntityEntries(eventData);
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

        public static SoftDeleteBoolSaveChangesInterceptor Create()
        {
            return new SoftDeleteBoolSaveChangesInterceptor();
        }
    }


}
