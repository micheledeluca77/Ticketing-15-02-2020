using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Data;
using Ticketing.Models;

namespace Ticketing.Repos
{
    public class UserRepo : IUserRepo
    {
        private DataContext _context;

        public UserRepo(DataContext ctx)
        {
            _context = ctx;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.AsEnumerable();
        }

        public void CreateUser(User newUser)
        {
            newUser.UserId = 0;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public void UpdateUser(User newUser)
        {
            _context.Users.First(d => d.UserId == newUser.UserId).FirstName = newUser.FirstName;
            _context.Users.First(d => d.UserId == newUser.UserId).LastName = newUser.LastName;
            _context.Users.First(d => d.UserId == newUser.UserId).IdentityCode = newUser.IdentityCode;
            _context.Users.First(d => d.UserId == newUser.UserId).Telephone = newUser.Telephone;
            _context.Users.First(d => d.UserId == newUser.UserId).Username = newUser.Username;
            _context.Users.First(d => d.UserId == newUser.UserId).Password = newUser.Password;
            _context.Users.First(d => d.UserId == newUser.UserId).IdentityCode = newUser.IdentityCode;
            _context.Users.First(d => d.UserId == newUser.UserId).InternalUser = newUser.InternalUser;
            _context.Users.First(d => d.UserId == newUser.UserId).CustomerUser = newUser.CustomerUser;
            _context.Users.First(d => d.UserId == newUser.UserId).SupplierUser = newUser.SupplierUser;
            _context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _context.Users
                .Include(a => a.Tickets)
                .FirstOrDefault(a => a.UserId == id);
        }

        public void DeleteUser(int id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            _context.SaveChanges();
        }
    }
}
