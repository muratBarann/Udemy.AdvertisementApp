﻿using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Extensions;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.Common;
using Udemy.AdvertisementApp.Common.Enums;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createValidator;
        private readonly IMapper _mapper;

        public AdvertisementAppUserService(IUow uow, IValidator<AdvertisementAppUserCreateDto> createValidator, IMapper mapper)
        {
            _uow = uow;
            _createValidator = createValidator;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createValidator.Validate(dto);
            if (result.IsValid)
            {

                var recort = await _uow.GetRepostiory<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);

                if (recort == null)
                {
                    var mappedData = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepostiory<AdvertisementAppUser>().CreateAsync(mappedData);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }
                List<CustomValidationError> errors = new List<CustomValidationError>{new CustomValidationError
                {
                    ErrorMessage = "Daha önce bu ilana başvuruldu 1 ilana sadece 1 kere başvurulabilir",
                    PropertyName = " "
                }};

                return new Response<AdvertisementAppUserCreateDto>(dto,errors);

            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<List<AdvertisemetAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepostiory<AdvertisementAppUser>().GetQuery();
            var list = await query.Include(x => x.Advertisement).Include(x => x.AppUser).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x=>x.AppUser.Gender).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();

            return _mapper.Map<List<AdvertisemetAppUserListDto>>(list);

        }

        public async Task SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepostiory<AdvertisementAppUser>().GetQuery();
            var entity =  await query.SingleOrDefaultAsync(x=>x.Id == advertisementAppUserId);
            entity.AdvertisementAppUserStatusId = (int)type;
            await _uow.SaveChangesAsync();
        }

    }
}
