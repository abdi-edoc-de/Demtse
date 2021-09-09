using Demጽ.DbContexts;
using Demጽ.Entities;
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

        public async Task DeleteSubscription(string userId, string channelId)
        {
            var results = await _appDbContext.Subscribtions.Where(sub => sub.UserId == userId && sub.ChannelId == channelId).ToArrayAsync();
            _appDbContext.Subscribtions.RemoveRange(results);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Channel>> GetSubscribedChannels(string userId)
        {
            return (await _appDbContext.Subscribtions
                .Where(sub => sub.UserId == userId)
                .Include(sub => sub.Channel)
                .ToListAsync())
                .ConvertAll(sub => sub.Channel);
        }
    }
}
