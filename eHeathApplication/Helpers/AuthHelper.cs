using eHeathApplication.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eHeathApplication.Helpers
{
    public class AuthHelper
    {
        public String Generatetoken(string name,string role)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, name),
        new Claim(ClaimTypes.Role, role)
    };
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
        public bool MatchPassword(string password1, byte[] password2, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {

                var passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password1));
                for (int i = 0; i < passwordhash.Length; i++)
                {
                    if (passwordhash[i] != password2[i])
                    {
                        return false;
                    }

                }
                return true;

            }
        }
    }
}
