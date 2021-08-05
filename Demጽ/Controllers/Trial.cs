using Demጽ.Entities;
using Demጽ.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demጽ.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Trial : ControllerBase
    {

        private readonly IWraperRepository _repositry;
        public Trial(IWraperRepository repository)
        {
            this._repositry = repository;

        }
        [HttpPost("audio")]
        public async Task<ActionResult> UploadAudio([FromBody] AudioCreationDto audio)
        {
            Audio audioForEntity = new Audio()
            {
                Path = audio.Path,
                Title = audio.Title,
                Description = audio.Description,
                PosterPath = audio.PosterPath
            };
            await _repositry.AudioRepository.Add(audioForEntity);
            return Ok(audioForEntity);


        
        }
    }
}
