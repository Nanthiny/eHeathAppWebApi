using eHeathApplication.Data;
using eHeathApplication.Helpers;
using eHeathApplication.IRepository;
using eHeathApplication.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eHeathApplication.Repository
{
    public class AuthRepo : IAuthRepo
    {
        private readonly ApplicationDbContext _db;
        public AuthRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<SignupResponse> AddUserToDb(RegisterModel model)
        {

            User user = new User();
            byte[] passwordhash, passwordkey;
            if (model != null)
            {
                using (var hmac = new HMACSHA512())
                {
                    passwordkey = hmac.Key;
                    passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));

                }

                user.Firstname = model.Firstname;
                user.Password = passwordhash;
                user.PasswordKey = passwordkey;
                user.Email = model.Email;
                user.Lastname = model.Lastname;

                _db.Users.Add(user);
                await _db.SaveChangesAsync();
            }


            return new SignupResponse {
            Email=user.Email,
            Message="Created",
            Success=true
            };
        }

        public async Task<SigninResponse> AuthenticateUser(string email, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
            AuthHelper helper = new AuthHelper();
            if (user == null)
            {
                return new SigninResponse {
                    Success=false,
                    Message="User not exist"
                };
            }
            if (!helper.MatchPassword(password, user.Password, user.PasswordKey))
            {
                return new SigninResponse
                {
                    Success = false,
                    Message = "User password not match"
                };
            }
           
           
            string tokenString = helper.Generatetoken();
            return new SigninResponse
            {
                Success = true,
                Message = "Successfully login",
                token = tokenString,
                userId=user.UserID,
                Firstname=user.Firstname
            };
        }

        public Task<IEnumerable<User>> getAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserAlreadyExist(string email)
        {
            throw new NotImplementedException();
        }
      
    }
}
