using Demጽ.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Models.Users
{
    public class LoginDto 
    {
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }

     
    }
}
