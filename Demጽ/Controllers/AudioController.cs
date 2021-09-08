using AutoMapper;
using Demጽ.Entities;
using Demጽ.Models.Audios;
using Demጽ.Repository.AdudioRepositories;
using Demጽ.Repository.ChannelRepositories;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Controllers
{
    [Route("api/Users/{UserId}/Audios")]
    [ApiController]

    public class AudioController : ControllerBase
    {
        private readonly string pathForFiles = Path.Join("Static", "Resources");
        private readonly IAudioRepository _AudioRepository;
        private readonly IMapper _mapper;

        private readonly IChannelRepository _ChannelRepository;

        public AudioController(IAudioRepository repository, IChannelRepository channelRepository)
        {
            _AudioRepository = repository;
            _ChannelRepository = channelRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Audio>>> GetRecentAudios(Guid userId)
        {
            IEnumerable<Audio> audios = await _AudioRepository.GetRecentAudios(userId);
            if (audios == null)
            {
                return NotFound();
            }
            return Ok(audios);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<AudioDto>> PostAudio(Guid UserId, IFormFile audioFile, [FromForm] AudioCreationDto audioCreationDto)
        {
            if (audioFile == null)
            {
                return BadRequest("Make sure you have the file is named file in the form");
            }

            Channel channel = new Channel
            {
                Name = "Everything is Alive",
                Description = "This is a cool podcast where we interview inanimate objects",
                ProfilePicture = "So this should be a path to profile pics",
                UserId = UserId.ToString(),

            };

            await _ChannelRepository.Add(channel);

            Audio audio = new Audio
            {
                Path = Path.Combine(pathForFiles, "Audios", Path.GetRandomFileName()),
                Title = audioCreationDto.Title,
                Description = audioCreationDto.Description,
                PosterPath = Path.Combine(pathForFiles, "Images", Path.GetRandomFileName()),
                ChannelId = channel.Id
            };

            using (var stream = System.IO.File.Create(audio.Path))
            {
                audioFile.CopyTo(stream);
            }

            // TODO: Add image

            await _AudioRepository.AddAudio(audio);
            AudioDto audioDto = new AudioDto
            {
                Name = audio.Title,
                NumberOfListeners = 123,
                ChannelName = audio.Channel.Name,
                Url = "http://localhost:44343/api/Users/" + UserId + "/Audios/" + audio.Id,
                Description = audio.Description,
                Id = Guid.Parse(audio.Id),
                ImageUrl = ""
            };
            // AudioDto audioToReturn = _mapper.Map<AudioDto>(audio);
            return Ok(audioDto);
        }

        [HttpGet("{AudioId}/Download")]
        public async Task<ActionResult> DownloadResource(Guid AudioId)
        {
            Audio audio = await _AudioRepository.GetAudio(AudioId);
            if (audio == null)
            {
                return NotFound();
            }
            var content = new FileStream(audio.Path, FileMode.Open, FileAccess.Read);
            var response = File(content, "application/octet-stream", audio.Title);
            return response;
        }

        [HttpGet("{AudioId}")]
        public async Task<ActionResult<AudioDto>> GetResource(Guid UserId, Guid AudioId)
        {
            Audio audio = await _AudioRepository.GetAudio(AudioId);
            if (audio == null)
            {
                return NotFound();
            }
            AudioDto audioDto = new AudioDto
            {
                Name = audio.Title,
                NumberOfListeners = 123,
                ChannelName = audio.Channel.Name,
                Url = "http://localhost:44343/api/Users/" + UserId + "/Audios/" + audio.Id,
                Description = audio.Description,
                Id = Guid.Parse(audio.Id),
                ImageUrl = ""
            };
            return Ok(audioDto);
        }

    }
}
