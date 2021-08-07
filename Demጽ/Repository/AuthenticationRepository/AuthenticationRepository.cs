using Demጽ.Entities;
using Demጽ.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace Demጽ.Repository.AuthenticationRepository
{
    public class AuthentiactionRepository : IAuthenticationRepository
    {
        private readonly UserManager<User> _userManger;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthentiactionRepository(UserManager<User> userManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
            this._userManger = userManager;
            this._configuration = configuration;
        }

        public async Task<bool> Exist(string userName)
        {
            var user = await _userManger.FindByNameAsync(userName);
            if (user == null)
            {
                return  false;
            }
            return true;
        }

        public async Task<LoginReturn> Login(LoginDto userCred)
        {
            var user = await _userManger.FindByNameAsync(userName: userCred.UserName);
            if (user != null && await _userManger.CheckPasswordAsync(user, userCred.Password))
            {
                var userRoles = await _userManger.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                   new Claim (ClaimTypes.Name,user.UserName),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                    );
             
                return new LoginReturn()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    User = user

                };

            }
            return null;
        }

        public async Task<User> Register(User user , String Password)
        {
            Console.WriteLine(user.UserName);

            var result = await _userManger.CreateAsync(user, Password);
            if (!result.Succeeded)

            {
                throw new ArgumentNullException(nameof(User));


            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
            var some = await _userManger.AddToRoleAsync(user, "User");
            var roles = await _userManger.GetRolesAsync(user);
            return user;
        }

        public Task<User> RegisterAdmin(User user , String Password)
        {
            throw new NotImplementedException();
        }
    }
}
