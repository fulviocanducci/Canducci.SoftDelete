using Canducci.SoftDelete;
using System;

namespace UnitTestSoftDelete.Models
{
    public class ModelDateTime : ISoftDeleteDateTime
    {
        public Guid Id { get; set; }

        public DateTime? DeletedAt { get; } = null;
    }
}
