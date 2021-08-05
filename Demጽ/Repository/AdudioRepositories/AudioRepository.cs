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
    }
}
