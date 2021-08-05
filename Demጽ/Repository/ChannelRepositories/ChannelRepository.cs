using Demጽ.DbContexts;
using Demጽ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository.ChannelRepositories
{
    public class ChannelRepository : Repository<Channel>,IChannelRepository
    {
        public ChannelRepository(AppDbContext appDbContext) : base(appDbContext)
        {


        }
    }
}
