using FluentValidation;
using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDTO>
    {
        public CategoryAddValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
        }

    }
}
