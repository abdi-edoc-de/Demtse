using Demጽ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.RecentlyPlayedRespositories
{
    public interface IRecentlyPlayedRepository : IRepository<RecentlyPlayed>
    {
        public Task<List<RecentlyPlayed>> GetRecents(String userId);
        // public Task<RecentlyPlayed> DeleteAll();
    }
}
