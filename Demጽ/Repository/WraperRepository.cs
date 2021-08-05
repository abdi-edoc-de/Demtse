using Demጽ.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demጽ.Repository.AdudioRepositories;
using Demጽ.Repository.SubscribeReopsitories;
using Demጽ.Repository.ChannelRepositories;

namespace Demጽ.Repository
{
    public class WraperRepository : IWraperRepository
    {

        private AppDbContext _appDbContext;
        private IAudioRepository _audioRepository;
        private IChannelRepository _channelRepository { get; set; }
        private ISubscribeRepository _subscribeRepository { get; set; }



        public WraperRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }






        public IAudioRepository AudioRepository {
            get
            {
                if (_audioRepository == null)
                {
                    _audioRepository = new AudioRepository(_appDbContext);

                }
                return _audioRepository;
            }
        
        }
        public IChannelRepository ChannelRepository
        {
            get
            {
                if (_channelRepository == null)
                {
                    _channelRepository = new ChannelRepository(_appDbContext);

                }
                return _channelRepository;
            }
        }    
        public ISubscribeRepository SubscribeRepository {
            get
            {
                if (_subscribeRepository == null)
                {
                    _subscribeRepository = new SubscribeRepository(_appDbContext);

                }
                return _subscribeRepository;
            }
        }

       
    }
}
