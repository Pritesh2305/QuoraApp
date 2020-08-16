using QuoraApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoraApp.Repository
{
    public interface IUserRepository
    {
        void InsertUser(User user);

        void UpdateUserDetails(User user);

        void UpdateUserPassword(User user);

        void DeleteUser(int uid);

        List<User> GetUsers();

        List<User> GetUsersByEmailAndPassword(string Email, string Password);

        List<User> GetUsersByEmail(string Email);

        List<User> GetUsersByUserID(int UserID);

    }

    public class UserRepository : IUserRepository
    {
        QuoraDBDataContext dc;

        public UserRepository()
        {
            dc = new QuoraDBDataContext();
        }

        public void DeleteUser(int uid)
        {



            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            List<User> Users = (from p in dc.Users
                                where p.IsAdmin == false
                                select p).ToList();

            return Users;
        }

        public List<User> GetUsersByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersByEmailAndPassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersByUserID(int UserID)
        {
            throw new NotImplementedException();
        }

        public void InsertUser(User user)
        {
            dc.Users.Add(user);
            dc.SaveChanges();
        }

        public void UpdateUserDetails(User user)
        {
            User existingUser = (from p in dc.Users
                                where p.UserID == user.UserID
                                select p).FirstOrDefault();

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Mobile = user.Mobile;
                existingUser.Email = user.Email;
                dc.SaveChanges();                
            }
        }

        public void UpdateUserPassword(User user)
        {
            User existingUser = (from p in dc.Users
                                     where p.UserID == user.UserID
                                     select p).FirstOrDefault();

            if (existingUser !=null)
            {
                existingUser.PasswordHash = user.PasswordHash;
                dc.SaveChanges();
            }            
        }
    }
}
