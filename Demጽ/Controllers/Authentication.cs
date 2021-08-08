using Demጽ.DbContexts;
using Demጽ.Entities;
using Demጽ.Models.Users;
using Demጽ.Repository;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IWraperRepository _repositry;



        public Authentication(IWraperRepository repository)
        {
            this._repositry = repository;


        }


        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register([FromBody] Register model)
        {
            var userExist = await _repositry.AuthenticationRepository.Exist(model.UserName);
            if (userExist)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "500", Message = "UserName Taken" });

            }


            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                ProfilePicture = model.ProfilePicture
            };

            var userFromRepo = await _repositry.AuthenticationRepository.Register(user, model.Password);

            return Ok(userFromRepo);



        }
        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {

            var userCred = await _repositry.AuthenticationRepository.Login(model);
            if (userCred == null)
            {
                return NotFound();
            }

            return Ok(userCred);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("checkroll")]

        public async Task<IActionResult> Login()
        {
            return Ok("its working");

        }
    }
}
