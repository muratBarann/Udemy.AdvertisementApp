using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Security.Cryptography.X509Certificates;
using Udemy.AdvertisementApp.UI.Models;

namespace Udemy.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz");
            RuleFor(x => x.Password).Equal(x=>x.ConfirmPassword).WithMessage("Sifreniz eslesmiyor.");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Sifre minumum 3 karakter olmalıdır");

            RuleFor(x => x.Username).MinimumLength(3).WithMessage("kullanıcı adı minumum 3 karakter olmalıdır");
            RuleFor(x=>x.Firstname).NotEmpty().WithMessage("İsim alanı boş olamaz");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soyad Boş olamaz");
            RuleFor(x=>x.GenderId).NotEmpty().WithMessage("Cinsiyet alanı doldurulmadılır");
            
            RuleFor(x=>new
            {
                x.Firstname,x.Username
            }).Must(x=>CanNotFirstName(x.Firstname,x.Username)).WithMessage("kullanıcı adı, adınınızı içeremez").When(x=>x.Username != null && x.Firstname != null);

        }

        private bool CanNotFirstName(string firstname, string username)
        {
            return !username.Contains(firstname);
        }
    }
}
