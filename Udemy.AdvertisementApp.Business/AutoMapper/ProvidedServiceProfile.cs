using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.AutoMapper
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceCreateDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServicesListDto, ProvidedServices>().ReverseMap();
            CreateMap<ProvidedServicesUpdateDto, ProvidedServices>().ReverseMap();
        }
    }
}
