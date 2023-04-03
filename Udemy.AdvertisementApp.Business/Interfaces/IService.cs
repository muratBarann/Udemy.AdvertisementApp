﻿using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Common;
using Udemy.AdvertisementApp.Dtos.Interfaces;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IDto, new()
        where ListDto : class, IDto, new()
        where T: BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync (CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync (UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsync(int id);
        Task<IResponse> RemoveAsync (int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
    }
}
