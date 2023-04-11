using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class ProvidedServiceService : Service<ProvidedServiceCreateDto,ProvidedServicesUpdateDto,ProvidedServicesListDto,ProvidedServices>,IProvidedService
    {
        public ProvidedServiceService(IMapper mapper,IUow uow,IValidator<ProvidedServiceCreateDto> createDtoValidator, IValidator<ProvidedServicesUpdateDto> updateDtoValidator) : base(mapper,createDtoValidator,updateDtoValidator, uow)
        {
            
        }
    }
}
