using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class SigninResponse
    {
        public bool Success { get; set; }
        public int? userId { get; set; }
        public string Firstname { get; set; }
        public string Message { get; set; }
        public string token { get; set; }
    }
}
