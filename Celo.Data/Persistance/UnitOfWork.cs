using Celo.Data.Interfaces;
using Celo.Data.Persistance.Interfaces;
using Celo.Data.Persistance.Repositories;
using System;
using System.Collections;

namespace Celo.Data.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IDbContext _context;
        protected IUserRepository _userRepository;
        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository != null) 
                    return _userRepository;
                else 
                    return _userRepository = new UserRepository(_context);
            }
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        private Hashtable _repositories;
        IRepository<T, TKey> IUnitOfWork.Repository<T, TKey>()
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(T).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepository<T, TKey>)_repositories[type];
            }
            var repositoryType = typeof(Repository<,>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(new Type[] { typeof(T), typeof(TKey) }), _context));
            return (IRepository<T, TKey>)_repositories[type];
        }
    }
}
