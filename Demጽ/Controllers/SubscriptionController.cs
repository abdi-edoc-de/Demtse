using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demጽ.Repository.SubscribeReopsitories;
using Demጽ.Models.Channels;
using Demጽ.Entities;

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
        public async Task<ActionResult> DeleteSubscription(Guid UserId, Guid ChannelId)
        {
            await _SubscriptionRepository.DeleteSubscription(UserId.ToString(), ChannelId.ToString());
            return Accepted();
        }

        [HttpGet]
        public async Task<ActionResult<List<ChannelDto>>> GetSubscribedChannels(Guid UserId)
        {
            return (await _SubscriptionRepository.GetSubscribedChannels(UserId.ToString()))
                .ConvertAll(channel => ConvertToChannelDto(channel));
        }

        public ChannelDto ConvertToChannelDto(Channel channel)
        {
            return new ChannelDto
            {
                Id = channel.Id,
                Name = channel.Name,
                ImageUrl = channel.ProfilePicture,
                Description = channel.Description,
                Subscribers = channel.Subscribtion.Count()
            };
        }
    }
}
