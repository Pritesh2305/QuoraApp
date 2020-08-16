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
            dc.Users.Remove(dc.Users.Find(uid));
            dc.SaveChanges();
        }

        public List<User> GetUsers()
        {
            List<User> Users = (from p in dc.Users
                                where p.IsAdmin == false
                                orderby p.Name
                                select p).ToList();
            return Users;
        }

        public List<User> GetUsersByEmail(string Email)
        {
            List<User> Users = (from p in dc.Users
                                where p.Email == Email
                                select p).ToList();
            return Users;
        }

        public List<User> GetUsersByEmailAndPassword(string Email, string Password)
        {
            List<User> Users = (from p in dc.Users
                                where p.Email == Email && p.PasswordHash == Password
                                select p
                                ).ToList();

            return Users;
        }

        public List<User> GetUsersByUserID(int UserID)
        {
            List<User> Users = (from p in dc.Users
                                where p.UserID == UserID
                                select p
                               ).ToList();

            return Users;
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
