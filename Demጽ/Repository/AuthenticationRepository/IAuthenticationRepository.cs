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
        Task<User> Get(String userId);
        Task<User> UpdateProfile( User user);
        Task<IEnumerable<String>> GetUserRoels(User user);

        Task<User> Update(UserUpdateDto userUpdate,String userId);
        Task<User> Get(String userId);
        Task<User> UpdateProfile( User user);
        Task<IEnumerable<String>> GetUserRoels(User user);

        Task<IEnumerable<String>> AddUserToCreateRole(User user);

        Task<IEnumerable<String>> RemoveUserFromCreateRole(String userId);
        Task<User> DeleteUser(String userId);
        
    }
}
