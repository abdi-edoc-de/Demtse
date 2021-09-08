using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Models.Audios
{
    public class AudioDto
    {
        public Guid Id { get; set; }

        public String Url { get; set; }

        public String Name { get; set; }

        public String ImageUrl { get; set; }

        public int NumberOfListeners { get; set; }

        public String ChannelName { get; set; }

        public String Description { get; set; }
    }
}
