using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.AutoMapper
{
    public class AdvertisementServiceProfile : Profile
    {
        public AdvertisementServiceProfile()
        {
            CreateMap<AdvertisementCreateDto, Advertisement>().ReverseMap();
            CreateMap<AdvertisementUpdateDto, Advertisement>().ReverseMap();
            CreateMap<AdvertisementListDto, Advertisement>().ReverseMap();
        }
    }
}
