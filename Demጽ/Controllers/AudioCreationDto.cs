using System;
using System.ComponentModel.DataAnnotations;

namespace Demጽ.Controllers
{
    public class AudioCreationDto
    { 

        [Required]
        [MaxLength(50)]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        public Guid ChannelId { get; set; }
    }
}