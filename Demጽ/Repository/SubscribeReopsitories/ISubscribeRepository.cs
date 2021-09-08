using Demጽ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.SubscribeReopsitories

{
    public interface ISubscribeRepository : IRepository<Subscribe>
    {

        Task<Subscribe> getSubscription(String UserId, String ChannelId);
        //Task<Subscribe> addSubscription(String UserId, String ChannelId);

    }
}
