using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Entities
{
    public class RecentlyPlayed
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public String Id { get; set; }

        [Required]
        public String AudioId { get; set; }

        [Required]
        public String UserId { get; set; }

        [Required]
        public DateTime ListenTime { get; set; }
    }
}
