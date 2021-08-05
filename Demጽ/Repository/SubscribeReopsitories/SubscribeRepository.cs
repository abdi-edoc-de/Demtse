using Demጽ.DbContexts;
using Demጽ.Entities;
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
}
}
