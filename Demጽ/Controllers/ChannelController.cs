using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Demጽ.Entities;
using Demጽ.Models;
using Demጽ.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demጽ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChannelController : ControllerBase
    {
        private readonly IWraperRepository _repository;

        public ChannelController(IWraperRepository repository)
        {
            _repository = repository;
        }

        // GET api/channel/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetChannel(String id)
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

            return Ok(ToDTO(channel));
        }

        // POST api/channel
        [Authorize]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> PostChannel(IFormFile file, IFormCollection formCollection)
        {
            if (file == null || formCollection["name"].ToString().Equals("") || formCollection["description"].ToString().Equals("") || formCollection["ownerId"].ToString().Equals(""))
            {
                return BadRequest("Make sure you have String name, File file, String description, String ownerId fields  in the form");
            }

            Channel channel = new Channel
            {
                Name = formCollection["name"].ToString(),
                Description = formCollection["description"].ToString(),
                ProfilePicture = Path.Combine(Path.Join("Static", "Resources", "Images", Path.GetRandomFileName())),
                UserId = formCollection["ownerId"].ToString()
            };

            try
            {
                using (var stream = System.IO.File.Create(channel.ProfilePicture))
                {
                    file.CopyTo(stream);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Channel createdChannel = null;

            try
            {
                createdChannel = await _repository.ChannelRepository.Add(channel);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(ToDTO(createdChannel));
        }

        // PUT api/channel/{id}
        [Authorize]
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> UpdateChannel(String id, IFormFile file, IFormCollection formCollection)
        {

            Channel channelFromDb = await _repository.ChannelRepository.Get(id);

            if (channelFromDb == null)
            {
                return NotFound();
            }

            if (file != null)
            {
                try
                {
                    using (var stream = System.IO.File.OpenWrite(channelFromDb.ProfilePicture))
                    {
                        file.CopyTo(stream);
                    }
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }


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

            return Ok(ToDTO(updatedChannel));

        }

        //Get api/channel/search/{searchString}
        [Authorize]
        [HttpGet("search/{searchString}")]
        public async Task<ActionResult> SearchChannel(String searchString)
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
            return Ok(ToDTOs(channelsFromDb));
        }

        // helper methods
        private ChannelDTO ToDTO(Channel channel)
        {
            return new ChannelDTO
            {
                Id = channel.Id,
                Name = channel.Name,
                Description = channel.Description,
                OwnerId = "channel.Owner.Id",
                ProfilePicture = channel.ProfilePicture,
                SubscribersNumber = "100" // TODO : read the data base and return number of subscribers
            };
        }

        private IEnumerable<ChannelDTO> ToDTOs(IEnumerable<Channel> channels)
        {
            return channels.Select<Channel, ChannelDTO>(channel => { return ToDTO(channel); });
        }
    }
}