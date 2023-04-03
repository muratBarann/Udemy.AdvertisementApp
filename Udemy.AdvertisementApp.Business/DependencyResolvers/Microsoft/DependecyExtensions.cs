using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.ValidationRules;
using Udemy.AdvertisementApp.DataAccess.Contexts;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;

namespace Udemy.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependecyExtensions
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });


            var mapperConfiguration = new MapperConfiguration(opt =>
            {

            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUow, Uow>();
            
            //Burada Dto'ların validatorlarının bağımlılıklarını(dependency) yapıyoruz
            services.AddTransient<IValidator<ProvidedServiceCreateDto>,ProvidedServicesCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServicesUpdateDto>, ProvidedServicesUpdateDtoValidator>();
        }
    }
}
