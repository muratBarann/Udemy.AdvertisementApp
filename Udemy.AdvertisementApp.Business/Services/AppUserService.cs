using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.Business.ValidationRules;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto,AppUserListDto,AppUser>,IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public AppUserService(IMapper mapper,IValidator<AppUserCreateDto> createValidator, IValidator<AppUserUpdateDto>updateValidator,IUow uow) : base(mapper,createValidator,updateValidator,uow)
        {
            _uow = uow;
            _mapper = mapper;
        }


    }
}
