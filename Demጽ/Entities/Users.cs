using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Entities
{
    public class Users:IdentityUser
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String ProfilePicture { get; set; }
        public Channel Channel { get; set; }

        public ICollection<Subscribe> Subscribtion { get; set; } 
            = new List<Subscribe>();

    }
}
