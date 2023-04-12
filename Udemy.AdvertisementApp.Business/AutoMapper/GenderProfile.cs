using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.AutoMapper
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<GenderCreateDto, Gender>().ReverseMap();
            CreateMap<GenderUpdateDto, Gender>().ReverseMap();
            CreateMap<GenderListDto, Gender>().ReverseMap();
        }
    }
}
