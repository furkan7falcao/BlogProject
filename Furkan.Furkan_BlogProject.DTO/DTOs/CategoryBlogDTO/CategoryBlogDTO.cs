using Furkan.Furkan_BlogProject.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.DTO.DTOs.CategoryBlogDTO
{
    public class CategoryBlogDTO : IDto
    {
        public int BlogId { get; set; }
        public int CategoryId { get; set; }

    }
}
