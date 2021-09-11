using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Demጽ.Entities;
using Demጽ.Models;
using Demጽ.Models.Channels;
using Demጽ.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demጽ.Controllers
{
    [ApiController]
    [Route("api/Users/{UserId}/[controller]")]
    public class ChannelController : ControllerBase
    {
        private readonly IWraperRepository _repository;

        public ChannelController(IWraperRepository repository)
        {
            _repository = repository;
        }

        //[Authorize]
        [HttpGet]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult<ChannelDto>> GetListOfChannels(Guid UserId)
        {
            return Ok((await _repository.ChannelRepository.GetAll()).ConvertAll(channel => ConvertToChannelDto(channel, UserId.ToString())));
        }

        // GET api/channel/{id}
        //[Authorize]
        [HttpGet("{id}")]
        //[Authorize(Roles = "User")]
        public async Task<ActionResult> GetChannel(Guid UserId, String id)
        {
            Channel channel = null;
            try
            {
                channel = await _repository.ChannelRepository.Get(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (channel == null)
                return NotFound();

            return Ok(ConvertToChannelDto(channel, UserId.ToString()));
        }

        // POST api/channel
        //[Authorize]
        [HttpPost]
        [Consumes("multipart/form-data")]
        //[Authorize(Roles = "User,Creator")]
        public async Task<ActionResult> PostChannel(IFormCollection formCollection)
        {
            if (formCollection["name"].ToString().Equals("") || formCollection["description"].ToString().Equals("") || formCollection["ownerId"].ToString().Equals(""))
            {
                return BadRequest("Make sure you have String name, File file, String description, String ownerId fields  in the form");
            }

            Channel channel = new Channel
            {
                Name = formCollection["name"].ToString(),
          
                Description = formCollection["description"].ToString(),
                ProfilePicture ="Static\\Resources\\Images\\Profiles\\rbhndnh0.3g3",
                UserId = formCollection["ownerId"].ToString()
            };

            //try
            //{
            //    using (var stream = System.IO.File.Create(channel.ProfilePicture))
            //    {
            //        file.CopyTo(stream);
            //    }
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}

            Channel createdChannel = null;


            createdChannel = await _repository.ChannelRepository.Add(channel);
    
            return Ok(ConvertToChannelDto(createdChannel, createdChannel.UserId));
        }

        // PUT api/channel/{id}
        //[Authorize]
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        //[Authorize(Roles = "User,Creator")]

        public async Task<ActionResult> UpdateChannel(Guid UserId,String id, IFormCollection formCollection)
        {

            Channel channelFromDb = await _repository.ChannelRepository.Get(id);

            if (channelFromDb == null)
            {
                return NotFound();
            }

            //if (file != null)
            //{
            //    try
            //    {
            //        using (var stream = System.IO.File.OpenWrite(channelFromDb.ProfilePicture))
            //        {
            //            file.CopyTo(stream);
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        return StatusCode(StatusCodes.Status500InternalServerError);
            //    }
            //}


            channelFromDb.Name = formCollection["name"].ToString() ?? channelFromDb.Name;
            channelFromDb.Description = formCollection["description"].ToString() ?? channelFromDb.Description;

            Channel updatedChannel = null;

            try
            {
                updatedChannel = await _repository.ChannelRepository.Update(channelFromDb);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(ConvertToChannelDto(updatedChannel, UserId.ToString()));

        }

        //Get api/channel/search/{searchString}
        //[Authorize]
        [HttpGet("search/{searchString}")]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult> SearchChannel(Guid UserId, String searchString)
        {
            IEnumerable<Channel> channelsFromDb = null;
            try
            {
                channelsFromDb = from channel in (await _repository.ChannelRepository.GetAll()) where channel.Name.Contains(searchString) select channel;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (channelsFromDb == null)
            {
                return NotFound();
            }
            return Ok(ToDTOs(channelsFromDb, UserId.ToString()));
        }

        //[Authorize]
        [HttpGet("yourchannel")]
        //[Authorize(Roles = "User,Creator")]

        public async Task<ActionResult> yourChannels(Guid UserId){
            String userId = UserId.ToString();
            IEnumerable<Channel> channelsFromDb = null;
            try
            {
                channelsFromDb = from channel in (await _repository.ChannelRepository.GetAll()) where channel.UserId.Equals(userId) select channel;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (channelsFromDb == null)
            {
                return NotFound();
            }
            return Ok(ToDTOs(channelsFromDb, userId));
        }

        public static ChannelDto ConvertToChannelDto(Channel channel, String userId)
        {
            return new ChannelDto
            {
                Id = channel.Id,
                Name = channel.Name,
                Url = $"api/Users/{userId}/Channel/profile/{channel.Id}",
                Description = channel.Description,
                Subscribers = channel.Subscribtion.Count(),
                Podcasts = channel.Audios.ToList().ConvertAll(audio => AudioController.ConvertToAudioDto(audio, userId)),
            };
        }
        // api for getting a specific channel by passing channelId
        [HttpGet]
        [Route("/profile/{channelId}")]
        public async Task<ActionResult> GetProfile(String userId,String channelId)
        {
            var channel = await _repository.ChannelRepository.Get(channelId);
            if (channel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "400", Message = "Channel dose not exist" });

            }
            var image = new FileStream(channel.ProfilePicture, FileMode.Open, FileAccess.Read);
            var response = File(image, "application/octet-stream", "placeholder.jpg");
            return response;
        }

        private IEnumerable<ChannelDto> ToDTOs(IEnumerable<Channel> channels, String userId)
        {
            return channels.Select<Channel, ChannelDto>(channel => { return ConvertToChannelDto(channel, userId); });
        }
    }
}