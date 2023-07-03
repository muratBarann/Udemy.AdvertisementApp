using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Common.Enums;
using Udemy.AdvertisementApp.Dtos;

namespace Udemy.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(x=>x.AppUserId).NotEmpty().WithMessage("Hangi kullanıcı");
            RuleFor(x=>x.AdvertisementAppUserStatusId).NotEmpty().WithMessage("DURUM");
            RuleFor(x=>x.MilitaryStatusId).NotEmpty().WithMessage("askerlik durum");
            RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli).WithMessage("Bir ilana sadece 1 kere başvurulabilir");
            RuleFor(x=>x.CvPath).NotEmpty().WithMessage("Bir cv dosyası seçiniz");
        }
    }
}
