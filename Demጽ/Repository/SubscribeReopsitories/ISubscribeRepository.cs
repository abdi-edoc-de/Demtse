using Demጽ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.SubscribeReopsitories

{
    public interface ISubscribeRepository : IRepository<Subscribe>
    {
        public Task<List<Channel>> GetSubscribedChannels(String userId);

        public Task DeleteSubscription(String userId, String channelId);
    }
}
