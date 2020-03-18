using System.Linq;

namespace Celo.Data.Interfaces
{
    public interface IRepository<T, TKey> where T : class, IEntityWithId<TKey>
    {
        T Get(TKey id);

        IQueryable<T> GetAll();

        T Add(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}