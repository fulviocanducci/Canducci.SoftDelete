using System;

namespace Canducci.SoftDelete
{
    public interface ISoftDeleteDateTime 
    { 
        DateTime? DeletedAt { get; }
    }
}
