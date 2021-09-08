using Demጽ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.AdudioRepositories

{
    public interface IAudioRepository :IRepository<Audio>
    {
        public Task<Audio> AddAudio(Audio audio);
        public Task<Audio> GetAudio(Guid audioId);

        public Task<List<Audio>> GetRecentAudios(Guid userId);
        public Task<List<Audio>> GetSubscribedAudios(Guid userId);
        public Task<List<Audio>> GetTrendingAudios();
        public Task<Audio> DeleteResource(Guid resourceId);
    }
}
