using Furkan.Furkan_BlogProject.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.DTO.DTOs.AppUserDTOs
{
    public class AppUserActiveDTO : IDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }

    }
}
