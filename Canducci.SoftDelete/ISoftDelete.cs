namespace Canducci.SoftDelete
{
    public interface ISoftDelete<T>
    {
        T DeletedAt { get; }
    }
}
