using FluentValidation;
using Furkan.Furkan_BlogProject.Business.Concreate;
using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.Business.Tools.JwtTool;
using Furkan.Furkan_BlogProject.Business.ValidationRules.FluentValidation;
using Furkan.Furkan_BlogProject.DataAccess.Concreate.EntityFrameworkCore.Repositories;
using Furkan.Furkan_BlogProject.DataAccess.Interface;
using Furkan.Furkan_BlogProject.DTO.DTOs.AppUserDTOs;
using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryBlogDTO;
using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryDTOs;
using Microsoft.Extensions.DependencyInjection;

namespace Furkan.Furkan_BlogProject.Business.Containers
{
    public static class MicrosoftIocExtension
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDAL<>),typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<IBlogService,BlogManager>();
            services.AddScoped<IBlogDAL, EfBlogRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EfCategoryRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDAL, EfAppUserRepository>();
            services.AddScoped<IJwtService, JwtManager>();


            services.AddTransient<IValidator<AppUserLoginDTO>, AppUserLoginValidator>();
            services.AddTransient<IValidator<CategoryAddDTO>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryBlogDTO>, CategoryBlogValidator>();
            services.AddTransient<IValidator<CategoryUpdateDTO>, CategoryUpdateValidator>();



        }
    }
}
