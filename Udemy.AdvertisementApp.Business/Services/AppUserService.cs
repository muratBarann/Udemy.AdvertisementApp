using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Extensions;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.Business.ValidationRules;
using Udemy.AdvertisementApp.Common;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<AppUserCreateDto> _createValidator;

        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createValidator, IValidator<AppUserUpdateDto> updateValidator, IUow uow) : base(mapper, createValidator, updateValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var validateResult = _createValidator.Validate(dto);
            if (validateResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                await _uow.GetRepostiory<AppUser>().CreateAsync(user);

                //1.adım

                //user.AppUserRoles = new List<AppUserRole>();
                //user.AppUserRoles.Add(new AppUserRole()
                //{
                //    AppUser = user,
                //    AppRoleId = roleId
                //});

                //2.adım

                await _uow.GetRepostiory<AppUserRole>().CreateAsync(new AppUserRole()
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _uow.SaveChangesAsync();

                return new Response<AppUserCreateDto>(ResponseType.Success,dto);

            }
            return new Response<AppUserCreateDto>(dto, validateResult.ConvertToCustomValidationError());
        }

    }
}
