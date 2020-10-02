using Canducci.SoftDelete;

namespace EF5CoreSoftDelete.Models
{
    public class People : ISoftDeleteBool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool DeletedAt { get; } = false;
    }
}
