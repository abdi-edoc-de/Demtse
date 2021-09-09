using Demጽ.DbContexts;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Audio> IncrementListeners(Audio audio)
        {
            _appDbContext.Audios
                .Update(audio);
            audio.NumberOfListeners++;
            await _appDbContext.SaveChangesAsync();
            return audio;
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
            return GetFirst(6);
        }

        public async Task<List<Audio>> GetSubscribedAudios(Guid userId)
        {
            var listOfSubscriptions = _appDbContext.Subscribtions
                .Where(sub => sub.UserId == userId.ToString())
                .Include(sub => sub.Channel)
                .ThenInclude(sub => sub.Audios
                    .OrderBy(audio => audio.UploadedDate)
                    .Take(5)
                )
                .ToList();
            List<Audio> result = new List<Audio>();
            listOfSubscriptions.ForEach(sub => result.AddRange(sub.Channel.Audios));
            return result; 
        }

        public Task<List<Audio>> GetTrendingAudios()
        {
            return GetLast(6);
        }

        public async Task<bool> DeleteAudiosOfChannel(String channelId)
        {
            var allAudios = await _appDbContext.Audios.Where(audio => audio.ChannelId == channelId).ToArrayAsync();
            _appDbContext.Audios.RemoveRange(allAudios);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
