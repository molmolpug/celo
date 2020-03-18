using System.Linq;
using Microsoft.EntityFrameworkCore;
using Celo.Data.Interfaces;

namespace Celo.Data.Persistance
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class, IEntityWithId<TKey>
    {
        protected readonly IDbContext _context;
        protected DbSet<T> _dbSet;

        public Repository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }

        public virtual T Get(TKey id)
        {
            var queryable = _context.Set<T>().Where(a => a.Id.Equals(id)).AsQueryable();
            return queryable.SingleOrDefault();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual void Update(T entity)
        {
            _context.Update(entity);
        }

        public virtual void Remove(T entity)
        {
            _context.Remove(entity);
        }
    }
}