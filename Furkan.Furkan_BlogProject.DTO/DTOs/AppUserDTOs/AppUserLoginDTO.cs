using Furkan.Furkan_BlogProject.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.DTO.DTOs.AppUserDTOs
{
    public class AppUserLoginDTO : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
