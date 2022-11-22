using StackOverFlow.DomainModels;
using StackOverFlow.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StackOverflowDatabaseDbContext _context;

        public UserRepository(StackOverflowDatabaseDbContext context)
        {
            _context = context;
        }

        public void InsertUser(User u)
        {
            _context.Users.Add(u);
            _context.SaveChanges();
        }

        public void UpdateUserDetails(User u)
        {
            //based on the userid present in the Users object,data will be retreived from the matching data
            //from the users table. only single record will be retreived.
            User us = _context.Users.Where(x => x.UserId == u.UserId).FirstOrDefault();
            if (us != null)
            {
                us.Name = u.Name;
                us.Mobile = u.Mobile;
                _context.SaveChanges();
            }
        }

        public void UpdateUserPassword(User u)
        {
            //based on the userid present in the Users object,data will be retreived from the matching data
            //from the users table. only single record will be retreived.
            User us = _context.Users.Where(x => x.UserId == u.UserId).FirstOrDefault();
            if (us != null)
            {
                us.PasswordHash = u.PasswordHash;
                _context.SaveChanges();
            }
        }


        public List<User> GetUsers()
        {
            List<User> us = _context.Users.Where(x => x.isAdmin == false).OrderBy(x => x.Name).ToList();
            return us;
        }

        public List<User> GetUsersByEmailAndPassword(string email, string password)
        {
            List<User> us = _context.Users.Where(x => x.Email == email && x.PasswordHash == password).ToList();
            return us;
        }

        public List<User> GetUsersByUserId(int userId)
        {
            List<User> us = _context.Users.Where(x => x.UserId == userId).ToList();
            return us;
        }

        public int GetLatestUserId()
        {
            int uid = _context.Users.Select(x => x.UserId).Max();
            return uid;
        }

        public void DeleteUser(int uid)
        {
            User us = _context.Users.Where(x => x.UserId == uid).FirstOrDefault();
            if (us != null)
            {
                _context.Users.Remove(us);
                _context.SaveChanges();
            }
        }
        
        public List<User> GetUsersByEmail(string email)
        {
            List<User> us = _context.Users.Where(x => x.Email == email).ToList();
            return us;

        }
    }
}
