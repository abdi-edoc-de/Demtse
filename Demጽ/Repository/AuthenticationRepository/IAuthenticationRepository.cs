using Demጽ.Entities;
using Demጽ.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.AuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        Task<User> Register(User user,string Password);
        Task<User> RegisterAdmin(User user , string Password);

        Task<LoginReturn> Login(LoginDto userCred);
        Task<bool> Exist(string userName);
        
    }
}
