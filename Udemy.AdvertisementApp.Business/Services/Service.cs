using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.Common;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos.Interfaces;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {

        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;

        public Service(IValidator<UpdateDto> updateDtoValidator)
        {
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepostiory<T>().CreateAsync(createdEntity);
                return new Response<CreateDto>(ResponseType.Success,dto);
            }
            return new Response<CreateDto>(dto,new());
        }

        public Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<IDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
