using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Entities
{
    public class Channel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String Id { get; set; }
        [Required]
        [MaxLength(30)]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String ProfilePicture { get; set; }
        [ForeignKey("UserId")]
        public Users Owner { get; set; }
        public String UserId { get; set; }
        public ICollection<Audio> Audios { get; set; } = new List<Audio>();
        public ICollection<Subscribe> Subscribtion { get; set; } = new List<Subscribe>();


    }
}
