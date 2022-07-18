using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class Admin:User
    {
        public string Role { get; set; } = "admin";
    }
}
