using Furkan.Furkan_BlogProject.DTO.DTOs.AppUserDTOs;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Furkan.Furkan_BlogProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Furkan.Furkan_BlogProject.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUserLoginDTO appUserLoginDTO);
        Task<AppUser> FindByNameAsync(string userName);

    }
}
