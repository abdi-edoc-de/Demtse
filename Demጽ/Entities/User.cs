using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Entities
{
    public class User:IdentityUser
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String ProfilePicture { get; set; }
        //public Channel Channel { get; set; }

        public virtual ICollection<Subscribe> Subscribtion { get; set; } 
            = new List<Subscribe>();
        public virtual List<Channel> Channels { get; set; } = new List<Channel>();
        [Required]
        public String ProfilePicName { get; set; } 

    }
}
