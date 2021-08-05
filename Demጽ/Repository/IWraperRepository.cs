using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demጽ.Repository.AdudioRepositories;
using Demጽ.Repository.ChannelRepositories;
using Demጽ.Repository.SubscribeReopsitories;

namespace Demጽ.Repository
{
    public interface IWraperRepository
    {
        public IAudioRepository AudioRepository { get;  }
        public IChannelRepository  ChannelRepository { get;  }
        public ISubscribeRepository SubscribeRepository { get;  }
    }
}
