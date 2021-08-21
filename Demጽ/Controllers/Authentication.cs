using AutoMapper;
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
        private readonly IMapper _mapper;



        public Authentication(IWraperRepository repository,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._repositry = repository;


        }


        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register([FromBody] UserCreationDto model)
        {
            var userExist = await _repositry.AuthenticationRepository.Exist(model.UserName);
            if (userExist)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "500", Message = "UserName Taken" });

            }
            User user = _mapper.Map<User>(model);
            user.SecurityStamp = Guid.NewGuid().ToString();

            var userFromRepo = await _repositry.AuthenticationRepository.Register(user, model.Password);
            var userToReturn = _mapper.Map<UserDto>(userFromRepo);
            return Ok(userToReturn);



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
        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("checkroll")]

        public async Task<IActionResult> Login()
        {
            return Ok("its working");

        }
    }
}
