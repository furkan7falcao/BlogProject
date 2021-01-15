using FluentValidation;
using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryDTOs;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Kategori Id Boş Geçilemez");
            RuleFor(I => I.Name).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
        }
    }
}
