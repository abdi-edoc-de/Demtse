using AutoMapper;
using Demጽ.Entities;
using Demጽ.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Profiles
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<UserCreationDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
