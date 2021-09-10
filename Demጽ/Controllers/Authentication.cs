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
using System.IO;
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
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "400", Message = "UserName Taken" });

            }
            User user = _mapper.Map<User>(model);
            user.SecurityStamp = Guid.NewGuid().ToString();
            

            var userFromRepo = await _repositry.AuthenticationRepository.Register(user, model.Password);
            if (userFromRepo == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "400", Message = "Password IS WEAK" });
            }
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
                //ModelState.AddModelError("error", "Email or Password is Incorrect");
                var map =new Dictionary<string, string>();
                map["error"] = "Email or Password is Incorrect";
                return BadRequest(map);
            }
            return Ok(userCred);
        }
[HttpPut]
        [Route("update /profile/{userId}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> UpdateUserProfile(IFormFile file, String userId)
        {
            if (file == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "400", Message =
                    "Make sure you have the file named file in form"
                    });
            }
            var user = await _repositry.AuthenticationRepository.Get(userId);
            
            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "400", Message = "User dose not exist" });
            }
            user.ProfilePicture = Path.Combine(pathForFiles, Path.GetRandomFileName());
            user.ProfilePicName = file.FileName;
            var userFromRepo = await _repositry.AuthenticationRepository.UpdateProfile(user);

            using (var stream = System.IO.File.Create(userFromRepo.ProfilePicture))
            {
                file.CopyTo(stream);
            }
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet]
        [Route("update /profile/{userId}")]
        public async Task<ActionResult> GetProfile(String userId)
        {
            var user = await _repositry.AuthenticationRepository.Get(userId);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "400", Message = "User dose not exist" });

            }
            var image = new FileStream(user.ProfilePicture, FileMode.Open, FileAccess.Read);
            var response = File(image, "application/octet-stream",user.ProfilePicName);
            return response;
        }

[HttpPost()]
        [Route("user/{userId}/role")]
        public async Task<ActionResult> AddUserToCreateRole(String userId)
        {
            var user = await _repositry.AuthenticationRepository.Get(userId);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "400", Message = "User dose not exist" });
            }
            var roles = await _repositry.AuthenticationRepository.AddUserToCreateRole(user);
            return Ok(roles);
        }
        
    }
}
