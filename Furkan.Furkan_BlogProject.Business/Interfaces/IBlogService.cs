using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryBlogDTO;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Furkan.Furkan_BlogProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CategoryBlogDTO = Furkan.Furkan_BlogProject.DTO.DTOs.CategoryBlogDTO.CategoryBlogDTO;

namespace Furkan.Furkan_BlogProject.Business.Interfaces
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<List<Blog>> GetAllSortedByReleaseTimeAsync();
        Task AddToCategoryAsync(CategoryBlogDTO categoryBlogAddDTO);
        Task RemoveFromCategoryAsync(CategoryBlogDTO categoryBlogAddDTO);
        Task<List<Blog>> GetAllWithCategoryIdAsync(int categoryId);


    }
}
