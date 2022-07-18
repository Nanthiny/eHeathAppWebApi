using eHeathApplication.IRepository;
using eHeathApplication.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthRepo _repo;
        public AuthenticationController(IAuthRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("login")]
        public async Task<IActionResult> SignInUser([FromBody] LoginModel loginmodel)
        {
            SigninResponse obj = await _repo.AuthenticateUser(loginmodel.Email, loginmodel.Password);
           
            return Ok(obj);
        }
        [HttpPost("register")]
        public async Task<IActionResult> SignUpUser([FromBody] RegisterModel model)
        {
            SignupResponse obj =await _repo.AddUserToDb(model);           
            
            return Ok(obj);
        }
    }
}
