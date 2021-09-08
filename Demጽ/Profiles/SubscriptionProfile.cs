using AutoMapper;
using Demጽ.Entities;
using Demጽ.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Profiles
{
    public class SubscriptionProfile : Profile
    {
        public SubscriptionProfile()
        {
            CreateMap<SubscriptionDto, Subscribe>();
        }


    }
}

