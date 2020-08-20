using AutoMapper;
using QuoraApp.DomainModels;
using QuoraApp.Repository;
using QuoraApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoraApp.ServiceLayer
{
    public interface IUserService
    {
        int InsertUser(RegisterViewModel uvm);

        void UpdateUserDetails(EditUserDetailsViewModel uvm);

        void UpdateUserPassword(EditUserPasswordViewModel uvm);

        void DeleteUser(int uid);

        List<UserViewModel> GetUsers();

        List<UserViewModel> GetUsersByEmailAndPassword(string Email, string Password);

        List<UserViewModel> GetUsersByEmail(string Email);

        List<UserViewModel> GetUsersByUserID(int UserID);
    }

    public class UserService : IUserService
    {
        IUserRepository ur;

        public UserService()
        {
            ur = new UserRepository();
        }

        public int InsertUser(RegisterViewModel uvm)
        {
            var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<RegisterViewModel, User>();
                        cfg.IgnoreUnmapped();
                    });
            IMapper mapper = config.CreateMapper();

            User u = mapper.Map<RegisterViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.InsertUser(u);
            int uid = ur.GetLatestUserID();

            return uid;
        }

    }
}
