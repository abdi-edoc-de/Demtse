using Demጽ.DbContexts;
using Demጽ.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Controllers
{
    [ApiController]
    [Route("api")]
    public class Authentication : Controller
    {
        
        private readonly AppDbContext _appDb;
        private readonly UserManager<Users> _userManger;


        public Authentication(AppDbContext appDb, UserManager<Users> userManager)
        {
            this._appDb = appDb;
            this._userManger = userManager;

        }


        [HttpGet]
        public IActionResult Index()
        {
            return Ok("hello world");
        }




        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExist = await _userManger.FindByNameAsync(model.UserName);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "500", Message = "UserName Taken" });

            }
            Users user = new Users()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ProfilePicture = model.ProfilePicture

            };


            var result = await _userManger.CreateAsync(user, model.Password);



            if (!result.Succeeded)

            {
                var errors = result.Errors;
                var message = string.Join(", ", result.Errors.Select(x => "Code " + x.Code + " Description" + x.Description));
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = "500",
                    Message = message
                });

            }
            return Ok(user);
        }

    }
}
