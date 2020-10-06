using Canducci.SoftDelete;
using System;

namespace UnitTestSoftDelete.Models
{
    public class ModelGenericBool : ISoftDelete<bool>
    {
        public Guid Id { get; set; }

        public bool DeletedAt { get; } = false;
    }
}
