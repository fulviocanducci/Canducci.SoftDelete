using Canducci.SoftDelete;
using System;

namespace UnitTestSoftDelete.Models
{

    public class ModelGenericDateTime : ISoftDelete<DateTime?>
    {
        public Guid Id { get; set; }

        public DateTime? DeletedAt { get; } = null;
    }
}
