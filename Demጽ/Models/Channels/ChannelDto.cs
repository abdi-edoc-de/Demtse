using Demጽ.Entities;
using Demጽ.Models.Audios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Models.Channels
{
    public class ChannelDto
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public String Description { get; set; }
        public int Subscribers { get; set; }
        public List<AudioDto> Podcasts { get; set; }

    }
}
