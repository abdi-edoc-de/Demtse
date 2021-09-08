using AutoMapper;
using Demጽ.Controllers;
using Demጽ.Models.Audios;
using Demጽ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Profiles
{
    public class AudioCreationProfile : Profile
    {
        public AudioCreationProfile()
        {
            CreateMap<AudioCreationDto, Audio>()
                ;
        }
    }
}
