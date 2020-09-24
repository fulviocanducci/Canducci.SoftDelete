using System;

namespace Canducci.SoftDelete
{
    public interface ISoftDelete<T>
    {
        T DeletedAt { get; set; }
    }
}
