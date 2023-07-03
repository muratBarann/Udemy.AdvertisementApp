using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class GenderService : Service<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>,IGenderService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public GenderService(IMapper mapper, IValidator<GenderCreateDto> creteValidator, IValidator<GenderUpdateDto> updateValidator, IUow uow) : base(mapper,creteValidator,updateValidator,uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
    }
}
