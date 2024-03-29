﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Enities;

namespace Udemy.AdvertisementApp.Business.Interfaces
{
    public interface IProvidedService : IService<ProvidedServiceCreateDto,ProvidedServicesUpdateDto,ProvidedServicesListDto,ProvidedServices>
    {

    }
}
