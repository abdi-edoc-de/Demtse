using Demጽ.Entities;
using Demጽ.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.SubscribeReopsitories

{
    public interface ISubscribeRepository : IRepository<Subscribe>
    {
        Task<Subscribe> AddSubscription(Subscribe subscribe);
        Task<Subscribe> getSubscription(String UserId, String ChannelId);
        //Task<Subscribe> addSubscription(String UserId, String ChannelId);

    }
}
