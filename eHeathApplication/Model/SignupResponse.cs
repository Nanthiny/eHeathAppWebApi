using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class SignupResponse
    {
        public bool Success { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
