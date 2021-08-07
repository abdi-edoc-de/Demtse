using Demጽ.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demጽ.Repository.AdudioRepositories;
using Demጽ.Repository.SubscribeReopsitories;
using Demጽ.Repository.ChannelRepositories;
using Demጽ.Repository.AuthenticationRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Demጽ.Entities;

namespace Demጽ.Repository
{
    public class WraperRepository : IWraperRepository
    {
        private readonly UserManager<User> _userManger;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        private AppDbContext _appDbContext;
        private IAudioRepository _audioRepository;
        private IChannelRepository _channelRepository;
        private ISubscribeRepository _subscribeRepository;
        private IAuthenticationRepository _authenticationRepository;



        public WraperRepository(AppDbContext appDbContext,
            UserManager<User> userManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
        {
            _appDbContext = appDbContext;
            this._roleManager = roleManager;
            this._userManger = userManager;
            this._configuration = configuration;

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

        public IAuthenticationRepository AuthenticationRepository {
            get
            {
                if (_authenticationRepository == null)
                {
                    _authenticationRepository = new AuthentiactionRepository(_userManger , _configuration,_roleManager);

                }
                return _authenticationRepository;
            }

        }

    }
}
