using AutoMapper;
using Furkan.Furkan_BlogProject.DTO.DTOs.AppUserDTOs;
using Furkan.Furkan_BlogProject.DTO.DTOs.BlogDTOs;
using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryDTOs;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Furkan.Furkan_BlogProject.WebApi.Models;

namespace Furkan.Furkan_BlogProject.WebApi.Mapping.MapProfile
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            CreateMap<BlogListDTO, Blog>();
            CreateMap<Blog,BlogListDTO>();

            CreateMap<BlogAddModel, Blog>();
            CreateMap<Blog, BlogAddModel>();

            CreateMap<BlogUpdateModel, Blog>();
            CreateMap<Blog, BlogUpdateModel>();

            CreateMap<CategoryAddDTO, CategoryAddDTO>();
            CreateMap<CategoryAddDTO, CategoryAddDTO>();

            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<Category, CategoryUpdateDTO>();

            CreateMap<CategoryListDTO, Category>();
            CreateMap<Category, CategoryListDTO>();

            CreateMap<AppUserLoginDTO, AppUser>();
            CreateMap<AppUser, AppUserLoginDTO>();


        }
    }
}
