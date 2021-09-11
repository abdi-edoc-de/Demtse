﻿using AutoMapper;
using Demጽ.Entities;
using Demጽ.Models.Audios;
using Demጽ.Repository.AdudioRepositories;
using Demጽ.Repository.ChannelRepositories;
using Demጽ.Repository.RecentlyPlayedRespositories;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IRecentlyPlayedRepository _RecentlyPlayedRepository;
        private readonly IChannelRepository _ChannelRepository;

        public AudioController(IAudioRepository repository, IChannelRepository channelRepository, IRecentlyPlayedRepository recentlyPlayedRepository)
        {
            _AudioRepository = repository;
            _ChannelRepository = channelRepository;
            _RecentlyPlayedRepository = recentlyPlayedRepository;
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
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
        //[Authorize(Roles = "User,Creator")]
        public async Task<ActionResult<AudioDto>> PostAudio(Guid UserId, IFormFile audioFile, [FromForm] AudioCreationDto audioCreationDto)
        {
            if (audioFile == null)
            {
                return BadRequest("Make sure you have the file is named file in the form");
            }

            Channel channel = await _ChannelRepository.Get(audioCreationDto.ChannelId.ToString());

            Audio audio = new Audio
            {
                Path = Path.Combine(pathForFiles, "Audios", Path.GetRandomFileName()),
                Title = audioCreationDto.Title,
                Description = audioCreationDto.Description,
                PosterPath = channel.ProfilePicture,
                ChannelId = channel.Id,
                NumberOfListeners = 0,
                UploadedDate = DateTime.Now
            };

            using (var stream = System.IO.File.Create(audio.Path))
            {
                audioFile.CopyTo(stream);
            }

            // TODO: Add image

            await _AudioRepository.AddAudio(audio);
            AudioDto audioDto = ConvertToAudioDto(audio, UserId.ToString());
            // AudioDto audioToReturn = _mapper.Map<AudioDto>(audio);
            return Ok(audioDto);
        }

        [HttpPatch("{AudioId}")]
        //[Authorize(Roles = "User,Creator")]

        public async Task<ActionResult<AudioDto>> EditResource(Guid UserId, Guid AudioId, [FromBody] AudioUpdateDto audioUpdateDto)
        {
            var audio = await _AudioRepository.Get(AudioId.ToString());
            if (audio == null)
            {
                return NotFound();
            } else if (audio.Channel.UserId != UserId.ToString())
            {
                return Unauthorized();
            }
            audio.Title = audioUpdateDto.Title;
            audio.Description = audioUpdateDto.Description;
            await _AudioRepository.Update(audio);
            return Accepted(ConvertToAudioDto(audio, UserId.ToString()));
        }

        [HttpGet("{AudioId}/Download.mp3")]
        //[Authorize(Roles = "User")]
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

        [HttpGet("Subscribed")]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult<List<AudioDto>>> GetSubscribedAudios(Guid UserId)
        {
            List<Audio> result = await _AudioRepository.GetSubscribedAudios(UserId);
            return Ok(result.ConvertAll(audio => ConvertToAudioDto(audio, UserId.ToString())));
        }

        [Authorize]
        [HttpGet("Trending")]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult<List<AudioDto>>> GetTrendingAudios(Guid UserId)
        {
            List<Audio> result = await _AudioRepository.GetTrendingAudios();
            return Ok(result.ConvertAll(audio => ConvertToAudioDto(audio, UserId.ToString())));
        }

        [HttpPost("{AudioId}/Played")]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult> PostRecentlyPlayed(Guid UserId, Guid AudioId)
        {
            var result = await _RecentlyPlayedRepository.Add(new RecentlyPlayed
            {
                AudioId = AudioId.ToString(),
                UserId = UserId.ToString(),
                ListenTime = DateTime.Now
            });

            await _AudioRepository.IncrementListeners(AudioId);
            return Accepted();
        }

        //[Authorize]
        [HttpGet("Recents")]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult<List<AudioDto>>> GetRecentlyPlayed(Guid UserId)
        {
            var results =  await _RecentlyPlayedRepository.GetAll();
            
            return Ok(results.ConvertAll(result => ConvertToAudioDto(result.Audio, UserId.ToString())));
        }

        [HttpDelete("{AudioId}")]
        //[Authorize(Roles = "User,Creator")]

        public async Task<ActionResult> DeleteResource(Guid UserId, Guid AudioId)
        {
            var result = await _AudioRepository.Get(AudioId.ToString());
            if (result == null)
            {
                return NotFound();
            }
            if (result.Channel.UserId != UserId.ToString())
            {
                return Unauthorized();
            }
            await _AudioRepository.Delete(AudioId.ToString());
            return Ok();
        }

        //[Authorize]
        [HttpGet("{AudioId}")]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult<AudioDto>> GetResource(Guid UserId, Guid AudioId)
        {
            Audio audio = await _AudioRepository.GetAudio(AudioId);
            if (audio == null)
            {
                return NotFound();
            }
            AudioDto audioDto = ConvertToAudioDto(audio, UserId.ToString());
            Console.WriteLine(audioDto.Url);
            return Ok(audioDto);
        }

        static public AudioDto ConvertToAudioDto(Audio audio, String UserId)
        {
            return new AudioDto
            {
                Name = audio.Title,
                NumberOfListeners = audio.NumberOfListeners,
                ChannelName = audio.Channel.Name,
                Url = "http://192.168.0.131:44343/api/Users/" + UserId + "/Audios/" + audio.Id + "/Download.mp3",
                Description = audio.Description,
                Id = Guid.Parse(audio.Id),
                ImageUrl = audio.Channel.ProfilePicture,
            };
        }

        [HttpGet("search/{searchString}")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<List<AudioDto>>> SearchPodcasts(Guid UserId, String searchString)
        {
            return Ok(
                (await _AudioRepository.TextSearchPodcasts(searchString))
                    .ConvertAll(audio => ConvertToAudioDto(audio, UserId.ToString())
                ));
        }



    }
}
