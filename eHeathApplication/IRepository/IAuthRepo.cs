using eHeathApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.IRepository
{
   public interface IAuthRepo
    {
        Task<SigninResponse> AuthenticateUser(string email, string password);
        //    Task<Admin> AuthenticateAdmin(string Email, string Password);
        Task<SignupResponse> AddUserToDb(RegisterModel model);
        //  Task<Admin> AddAdminToDb(AdminModel model);
        Task<bool> UserAlreadyExist(string email);

        Task<IEnumerable<User>> getAllUsers();
    }
}
