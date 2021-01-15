using Furkan.Furkan_BlogProject.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.DTO.DTOs.CategoryDTOs
{
    public class CategoryListDTO : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
