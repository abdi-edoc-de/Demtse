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
        [Required]
        public String Path { get; set; }
        [Required]
        public String PosterPath { get; set; }
    }
}