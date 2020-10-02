using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Canducci.SoftDelete.Internals
{
    internal sealed class Entries<T>: List<EntityEntry>
    {
        internal DbContextEventData EventData { get; }

        public Entries(DbContextEventData eventData)
        {
            EventData = eventData;
            GetEntityEntries(eventData);
        }

        internal bool Wheres(EntityEntry where)
        {
            return where.State == EntityState.Deleted &&
                    where.Entity.GetType().GetInterfaces()
                        .Contains(typeof(T));
        }

        internal void GetEntityEntries(DbContextEventData eventData)
        {
            AddRange(EventData.Context.ChangeTracker.Entries().Where(Wheres).ToList());
        }
    }
}
