using Demጽ.Entities;
using Demጽ.Models.Audios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Demጽ.Profiles
{
    public class AudioProfile : Profile
    {
        public AudioProfile()
        {
            CreateMap<Audio, AudioDto>()
                .ForMember(
                dest => dest.NumberOfListeners,
                opt => opt.MapFrom(src => 123)
                )
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => "pipip"))
                .ForMember(
                dest => dest.ChannelName,
                opt => opt.MapFrom(src => "I don't know how to get this"))
                .ForMember(
                dest => dest.ImageUrl,
                opt => opt.MapFrom(src => "https"))
                .ForMember(
                dest => dest.Url,
                opt => opt.MapFrom(src => "https"))
                ;
        }
        
            
    }
}
