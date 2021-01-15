using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.DataAccess.Interface;
using Furkan.Furkan_BlogProject.DTO.DTOs.AppUserDTOs;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Furkan.Furkan_BlogProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Furkan.Furkan_BlogProject.Business.Concreate
{
    public class AppUserManager : GenericManager<AppUser> , IAppUserService
    {
        private readonly IAppUserDAL _appUserDAL;
        public AppUserManager(IAppUserDAL appUserDAL) : base(appUserDAL)
        {
            _appUserDAL = appUserDAL;
        }

        public async Task<AppUser> CheckUserAsync(AppUserLoginDTO appUserLoginDTO)
        {
            return await _appUserDAL.GetAsync(I => I.UserName == appUserLoginDTO.UserName && I.Password == appUserLoginDTO.Password);
        }

        public async Task<AppUser> FindByNameAsync(string userName)
        {
            return await _appUserDAL.GetAsync(I => I.UserName == userName);
        }
    }
}
