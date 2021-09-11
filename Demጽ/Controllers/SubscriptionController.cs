using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demጽ.Repository.SubscribeReopsitories;
using Demጽ.Models.Channels;
using Demጽ.Entities;
using Demጽ.Models.Audios;
using Microsoft.AspNetCore.Authorization;

namespace Demጽ.Controllers
{
    [Route("api/Users/{UserId}/Subscriptions")]
    [ApiController]

    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscribeRepository _SubscriptionRepository;

        public SubscriptionController(ISubscribeRepository subscribeRepository)
        {
            _SubscriptionRepository = subscribeRepository;
        }

        [HttpPut("{ChannelId}")]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult> PostSubscription(Guid UserId, Guid ChannelId)
        {
            await _SubscriptionRepository.Add(new Entities.Subscribe
            {
                ChannelId = ChannelId.ToString(),
                UserId = UserId.ToString(),
                Nofication = false,
            });
            return Accepted();
        }

        [HttpDelete("{ChannelId}")]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult> DeleteSubscription(Guid UserId, Guid ChannelId)
        {
            await _SubscriptionRepository.DeleteSubscription(UserId.ToString(), ChannelId.ToString());
            return Accepted();
        }

        [HttpGet]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult<List<ChannelDto>>> GetSubscribedChannels(Guid UserId)
        {
            return (await _SubscriptionRepository.GetSubscribedChannels(UserId.ToString()))
                .ConvertAll(channel => ChannelController.ConvertToChannelDto(channel, UserId.ToString()));
        }

        [HttpGet("{ChannelId}")]
        //[Authorize(Roles = "User")]

        public async Task<ActionResult> GetSubscription(Guid UserId, Guid ChannelId)
        {
            var result = await _SubscriptionRepository.GetSubscribe(UserId.ToString(), ChannelId.ToString());
            if (result == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
