using Demጽ.DbContexts;
using Demጽ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.AdudioRepositories

{
    public class AudioRepository : Repository<Audio>,IAudioRepository
    {
        public AudioRepository(AppDbContext appDbContext) : base (appDbContext)
        {
        }

        public Task<Audio> AddAudio(Audio audio)
        {
            return Add(audio);
        }

        public Task<Audio> DeleteResource(Guid resourceId)
        {
            return Delete(resourceId.ToString());
        }

        public Task<Audio> GetAudio(Guid audioId)
        {
            return Get(audioId.ToString());
        }

        public Task<List<Audio>> GetRecentAudios(Guid userId)
        {
            // TODO: Actual implementation of this
            return GetAll();
        }

        public Task<List<Audio>> GetSubscribedAudios(Guid userId)
        {
            // TODO: Implment this too
            return GetAll();
        }
    }
}
