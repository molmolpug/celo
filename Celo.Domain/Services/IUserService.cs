using Celo.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Celo.Domain.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(string term, int limit);
        User GetUser(Guid id);
        void AddUser(User user);
        void UpdateUser(Guid id, User user);
        void DeleteUser(Guid id);
    }
}
