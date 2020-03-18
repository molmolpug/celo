using Celo.Data.Interfaces;
using Celo.Data.Models;
using Celo.Data.Persistance.Interfaces;
using System;
using System.Linq;

namespace Celo.Data.Persistance.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(IDbContext context) : base(context) { }

        public IQueryable<User> GetUsers(string term, int limit = 20)
        {
            return GetAll().Where(x => string.IsNullOrEmpty(term) ||
            x.FirstName.ToLower() == term.ToLower() ||
            x.LastName.ToLower() == term.ToLower()).Take(limit);
        }
    }
}
