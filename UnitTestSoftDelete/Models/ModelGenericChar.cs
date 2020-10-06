using Canducci.SoftDelete;
using System;

namespace UnitTestSoftDelete.Models
{
    public class ModelGenericChar : ISoftDelete<Char>
    {
        public Guid Id { get; set; }
        public char DeletedAt { get; } = 'N';
    }
}
