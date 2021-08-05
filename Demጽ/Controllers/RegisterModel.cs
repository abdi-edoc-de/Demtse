using System;
using System.ComponentModel.DataAnnotations;

namespace Demጽ.Controllers
{
    public class RegisterModel

    {
        public String Password { get; set; }
        public String Email { get; set; }
        public String UserName { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String ProfilePicture { get; set; }

    }
}