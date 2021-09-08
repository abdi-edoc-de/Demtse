using AutoMapper;
using Demጽ.Entities;
using Demጽ.Models.Subscription;
using Demጽ.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Controllers
{
    [ApiController]
    [Route("api")]
    public class SubscriptionController : Controller
    {
        private readonly IWraperRepository _repositry;
        private readonly IMapper _mapper;
            

        public SubscriptionController(IWraperRepository repository,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._repositry = repository;
        }

        [HttpPost]
        [Route("subscribe")]
        public async Task<IActionResult> subscribe([FromBody] SubscriptionDto subscriptionDto)
        {

            Subscribe subscribtion = _mapper.Map<Subscribe>(subscriptionDto);

            var subs = await _repositry.SubscribeRepository.Add(subscribtion);


            return Ok(subs);

        }


        [HttpPost]
        [Route("unsubsribe")]
        public async Task<IActionResult> unsubscribe([FromBody] String channelID, String UserID)
        {

            var subscription = await _repositry.SubscribeRepository.getSubscription(UserID, channelID);
            var result = await _repositry.SubscribeRepository.Delete(subscription.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("isSubscribed")]
        public async Task<IActionResult> IsSubscribed([FromBody] String UserId, String channelId)
        {
           
             
            var result = await _repositry.SubscribeRepository.getSubscription(UserId, channelId);

            if(result == null)
            {
                return Ok(false);

            }
                return Ok(true);
        }

    }
}
