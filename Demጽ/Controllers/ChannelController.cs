using System;
using System.Collections.Generic;
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
        [Authorize(Roles = "Creator")]
        [HttpPost]
        public async Task<ActionResult> PostChannel([FromBody] ChannelCreationDTO model)
        {
            Channel channel = null;
            try
            {
                channel = new Channel
                {
                    Name = model.Name,
                    Description = model.Description,
                    ProfilePicture = model.ProfilePicture,
                    UserId = model.OwnerId
                };
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
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
        public async Task<ActionResult> UpdateChannel(String id, [FromBody] ChannelCreationDTO model)
        {

            Channel channelFromDb = await _repository.ChannelRepository.Get(id);

            if (channelFromDb == null)
            {
                return NotFound();
            }

            var channel = new Channel
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
                ProfilePicture = model.ProfilePicture,
                UserId = model.OwnerId
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