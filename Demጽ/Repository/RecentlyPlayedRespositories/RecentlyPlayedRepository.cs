using Demጽ.DbContexts;
using Demጽ.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.RecentlyPlayedRespositories
{
    public class RecentlyPlayedRepository : Repository<RecentlyPlayed>, IRecentlyPlayedRepository
    {
        public RecentlyPlayedRepository(AppDbContext appDbContext): base(appDbContext)
        {

        }

        public async Task<List<RecentlyPlayed>> GetRecents(String userId)
        {
            //TODO: Fix the sorting
            return _appDbContext.RecentlyPlayeds
                .Where(play => play.UserId == userId)
                .OrderByDescending(play => play.ListenTime.Ticks)
                .ToList();
        }
    }
}
