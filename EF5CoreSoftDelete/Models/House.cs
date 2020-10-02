using Canducci.SoftDelete;

namespace EF5CoreSoftDelete.Models
{
    public class House : ISoftDeleteChar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char DeletedAt { get; } = 'N';
    }
}
