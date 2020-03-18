using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Celo.Data.Interfaces
{
    public interface IDbContext
    {
        IModel Model { get; }

        DbSet<T> Set<T>() where T : class;

        void Dispose();

        int SaveChanges();

        EntityEntry<T> Update<T>(T entity) where T : class;

        void UpdateRange(params object[] entities);

        EntityEntry<T> Remove<T>(T entity) where T : class;
    }
}