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
        private readonly IValidator<AppUserLoginDto> _loginValidator;

        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createValidator, IValidator<AppUserUpdateDto> updateValidator, IUow uow, IValidator<AppUserLoginDto> loginValidator) : base(mapper, createValidator, updateValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _loginValidator = loginValidator;
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

        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationResult = _loginValidator.Validate(dto);
            if(validationResult.IsValid)
            {
                var user = await _uow.GetRepostiory<AppUser>().GetByFilterAsync(x=>x.Username == dto.Username && x.Password == dto.Password);
                if(user != null)
                {
                    var mappedData = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success,mappedData);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Kullanıcı yada Şifre hatalı");
            }

            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı yada Şifre boş olamaz");
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByIdAsync(int userId)
        {
            var roles = await _uow.GetRepostiory<AppRole>().GetAllAsync(x=>x.AppUserRoles.Any(x=>x.AppUserId == userId));

            if(roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "İlgili rol bulunamadı");
            }

            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
        }

    }
}
