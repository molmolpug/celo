using Celo.Data.Interfaces;
using Celo.Data.Models;
using System;
using System.Linq;

namespace Celo.Data.Persistance.Interfaces
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        IQueryable<User> GetUsers(string term, int limit);
    }
}
