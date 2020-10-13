using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Canducci.SoftDelete.Internals
{
    public abstract class Entries<T>
    {
        private bool Wheres(EntityEntry where)
        {
            if (where is null)
            {
                throw new ArgumentNullException(nameof(where));
            }

            return where.State == EntityState.Deleted &&
                    where.Entity.GetType().GetInterfaces()
                        .Contains(typeof(T));
        }

        public List<EntityEntry> GetEntityEntries(DbContextEventData eventData)
        {
            if (eventData is null)
            {
                throw new ArgumentNullException(nameof(eventData));
            }
            return eventData.Context.ChangeTracker.Entries().Where(Wheres).ToList();
        }
    }
}
