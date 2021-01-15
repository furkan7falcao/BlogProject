using FluentValidation;
using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryBlogDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.Business.ValidationRules.FluentValidation
{
    public class CategoryBlogValidator : AbstractValidator<CategoryBlogDTO>
    {
        public CategoryBlogValidator()
        {
            RuleFor(I => I.CategoryId).InclusiveBetween(0, int.MaxValue).WithMessage("Kategori Id Boş Geçilemez");
            RuleFor(I => I.BlogId).InclusiveBetween(0, int.MaxValue).WithMessage("Blog Id Boş Geçilemez");

        }
    }
}
