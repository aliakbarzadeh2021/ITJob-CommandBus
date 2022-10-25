using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ITJob.DomainModel.Modules.AdvertisementModule.Aggregates;
using ITJob.QueryModels.Interfaces.AdvertisementModule;

namespace ITJob.QueryService.Implements.AdvertisementModule.Mappers
{
    public class AdvertismentMapperProfile : Profile
    {
        public AdvertismentMapperProfile()
        {
            CreateMap<Advertisement, IAdvertisementDto>();
            CreateMap<IAdvertisementDto, Advertisement>();
        }
    }
}
