using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demጽ.Entities;
namespace Demጽ.Models.Users
{
    public class LoginReturn
    {
        public String Token { get; set; }
        public DateTime Expiration { get; set; }
        public UserDto User { get; set; }
    }
}
