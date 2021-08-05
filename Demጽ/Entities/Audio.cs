using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Entities
{
    public class Audio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String Id { get; set; }

        [ForeignKey("ChannelId")]
        public Channel Channel { get; set; }
        public String ChannelId { get; set; }

        [Required]
        [MaxLength(50)]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Path { get; set; }
        [Required]
        public String PosterPath { get; set; }

    }
}
