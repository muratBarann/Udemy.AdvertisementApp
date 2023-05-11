using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos.ProvidedServiceDtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceCreateDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceListDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDto, ProvidedServices>().ReverseMap();
        }
    }
}
