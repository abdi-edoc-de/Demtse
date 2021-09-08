using Demጽ.DbContexts;
using Demጽ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.SubscribeReopsitories

{
    public class SubscribeRepository : Repository<Subscribe>, ISubscribeRepository
{
    public SubscribeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

        //public async Task<Subscribe> addSubscription(string UserId, string ChannelId)
        //{
        //    var result = await _appDbContext.AddAsync<Subscribe>(UserId);


        //    return result;
        //}

        public async Task<Subscribe> getSubscription(string UserId, string ChannelId)
        {
            var result = await _appDbContext.FindAsync<Subscribe>(UserId = UserId, ChannelId = ChannelId);



            return result;
        }
    }
}
