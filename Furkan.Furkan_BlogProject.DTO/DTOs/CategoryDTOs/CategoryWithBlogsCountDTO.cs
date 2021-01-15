using Furkan.Furkan_BlogProject.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.DTO.DTOs.CategoryDTOs
{
    public class CategoryWithBlogsCountDTO
    {
        public int BlogsCount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


    }
}
