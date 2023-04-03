using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos.ProvidedServicesDtos;

namespace Udemy.AdvertisementApp.Business.ValidationRules
{
    public class ProvidedServicesCreateDtoValidator : AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServicesCreateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}
