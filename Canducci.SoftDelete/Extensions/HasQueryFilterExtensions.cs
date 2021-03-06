﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Canducci.SoftDelete.Extensions
{
    public static class HasQueryFilterExtensions
    {
        public static EntityTypeBuilder<T> HasQueryFilterSoftDeleteDateTime<T>(
            this EntityTypeBuilder<T> option
        ) where T : class
        {
            return option.HasQueryFilter(x => ((ISoftDeleteDateTime)x).DeletedAt == null);
        }
        public static EntityTypeBuilder<T> HasQueryFilterSoftDeleteBool<T>(
            this EntityTypeBuilder<T> option
        ) where T : class
        {
            //option.HasQueryFilter(x => EF.Property<bool>(x, "DeletedAt") == false);
            return option.HasQueryFilter(x => ((ISoftDeleteBool)x).DeletedAt == false);
        }

        public static EntityTypeBuilder<T> HasQueryFilterSoftDeleteChar<T>(
            this EntityTypeBuilder<T> option
        ) where T : class
        {
            return option.HasQueryFilter(x => ((ISoftDeleteChar)x).DeletedAt == 'N');
        }
    }

}

