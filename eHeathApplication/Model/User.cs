using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eHeathApplication.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public byte[] Password { get; set; }
        public byte[] PasswordKey { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}
