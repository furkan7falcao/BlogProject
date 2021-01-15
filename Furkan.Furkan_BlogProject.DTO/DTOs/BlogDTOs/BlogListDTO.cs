using Furkan.Furkan_BlogProject.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.DTO.DTOs.BlogDTOs
{
    public class BlogListDTO : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public DateTime ReleaseTime { get; set; }
    }
}
