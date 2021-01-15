using FluentValidation;
using Furkan.Furkan_BlogProject.DTO.DTOs.AppUserDTOs;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDTO>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola Boş Geçilemez");
        }
    }
}
