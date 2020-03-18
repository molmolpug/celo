namespace Celo.Data.Interfaces
{
    public interface IEntityWithId<TKey>
    {
        TKey Id { get; set; }
    }
}
