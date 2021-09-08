using Demጽ.DbContexts;
using Demጽ.Entities;
using Demጽ.Models.Subscription;
using Microsoft.EntityFrameworkCore;
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
            var result = await _appDbContext.Subscribtions.FirstOrDefaultAsync(s => s.ChannelId == ChannelId && s.UserId == UserId);

            return result;
        }

        public async Task<Subscribe> AddSubscription(Subscribe subscribe)
        {

            var result = await _appDbContext.Subscribtions.AddAsync(subscribe);
            await _appDbContext.SaveChangesAsync();
            return (Subscribe)result;
        }
    }
}
