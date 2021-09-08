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
        [Authorize(Roles = "User")]
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
        // [Authorize(Roles = "Creator")]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> PostChannel(IFormFile file, IFormCollection model)
        {
            if (file == null || model["name"].ToString().Equals("") || model["description"].ToString().Equals("") || model["ownerId"].ToString().Equals(""))
            {
                return BadRequest("Make sure you have String name, File file, String description, String ownerId fields  in the form");
            }

            // System.Console.WriteLine(file.Name);
            // System.Console.WriteLine(model["name"]);
            // System.Console.WriteLine(model["description"]);
            // System.Console.WriteLine(model["ownerId"]);

            Channel channel = new Channel
            {
                Name = model["name"].ToString(),
                Description = model["description"].ToString(),
                ProfilePicture = Path.Combine(Path.Join("Static"), Path.GetRandomFileName()),
                UserId = model["ownerId"].ToString()
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
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> UpdateChannel(String id, [FromBody] ChannelCreationDTO model, IFormFile file)
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

            var channel = new Channel
            {
                Id = channelFromDb.Id,
                Name = model.Name ?? channelFromDb.Name,
                Description = model.Description ?? channelFromDb.Description,
                ProfilePicture = channelFromDb.ProfilePicture,
                UserId = channelFromDb.UserId
            };

            Channel updatedChannel = null;

            try
            {
                updatedChannel = await _repository.ChannelRepository.Update(channel);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(ToDTO(updatedChannel));

        }

        //Get api/channel/search/{searchString}
        [HttpGet("search/{searchString}")]
        public async Task<ActionResult> SearchChannel(String searchString)
        {
            var channelsFromDb = from channel in (await _repository.ChannelRepository.GetAll()) where channel.Name.Contains(searchString) select channel;

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
                OwnerId = channel.Owner.Id,
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