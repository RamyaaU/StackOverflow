using StackOverFlow.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void InsertUser(User u);

        void UpdateUserDetails(User u);

        void UpdateUserPassword(User u);

        void DeleteUser(int uid);

        List<User> GetUsers();

        List<User> GetUsersByEmailAndPassword(string email, string password);

        List<User> GetUsersByEmail (string email);
        List<User> GetUsersByUserId (int userId);

        //after successful insertion, if you need to access user by user id
        int GetLatestUserId();
    }
}
