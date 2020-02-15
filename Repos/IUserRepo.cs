using System.Collections.Generic;
using Ticketing.Models;

namespace Ticketing.Repos
{
    public interface IUserRepo
    {
        void CreateUser(User newUser);
        void DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
        User GetUser(int id);
        void UpdateUser(User newUser);
    }
}