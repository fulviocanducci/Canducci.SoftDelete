using Canducci.SoftDelete;
using System;

namespace EF5CoreSoftDelete.Models
{
    public class Animal: ISoftDeleteDateTime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DeletedAt { get; }
    }
}
