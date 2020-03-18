using Celo.Data.Interfaces;
using Celo.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Celo.Data.Persistance.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<T, TKey> Repository<T, TKey>() where T : class, IEntityWithId<TKey>;
        IUserRepository UserRepository { get; }
    }
}
