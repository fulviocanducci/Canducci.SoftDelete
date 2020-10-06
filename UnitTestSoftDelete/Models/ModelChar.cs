using Canducci.SoftDelete;
using System;

namespace UnitTestSoftDelete.Models
{
    public class ModelChar : ISoftDeleteChar
    {
        public Guid Id { get; set; }

        public char DeletedAt { get; } = 'N';
    }
}
