using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.DataAccess.Interface;
using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryBlogDTO;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Furkan.Furkan_BlogProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CategoryBlogDTO = Furkan.Furkan_BlogProject.DTO.DTOs.CategoryBlogDTO.CategoryBlogDTO;

namespace Furkan.Furkan_BlogProject.Business.Concreate
{
    public class BlogManager : GenericManager<Blog> , IBlogService
    {
        private readonly IBlogDAL _blogDAL;
        private readonly IGenericDAL<CategoryBlog> _categoryBlogDAL;
        public BlogManager(IBlogDAL blogDAL, IGenericDAL<CategoryBlog> categoryBlogDAL) : base(blogDAL)
        {
            _blogDAL = blogDAL;
            _categoryBlogDAL = categoryBlogDAL;
        }

        public async Task<List<Blog>> GetAllSortedByReleaseTimeAsync()
        {
            return await _blogDAL.GetAllAsync(I => I.ReleaseTime);
        }

        public async Task AddToCategoryAsync(CategoryBlogDTO categoryBlogAddDTO)
        {
            var control = await _categoryBlogDAL.GetAsync(I => I.BlogId == categoryBlogAddDTO.BlogId && I.CategoryId == categoryBlogAddDTO.CategoryId);

            if(control == null)
            {
                await _categoryBlogDAL.AddAsync(new CategoryBlog
                {
                    BlogId = categoryBlogAddDTO.BlogId,
                    CategoryId = categoryBlogAddDTO.CategoryId
                });
            }
           
        }

        public async Task RemoveFromCategoryAsync(CategoryBlogDTO categoryBlogAddDTO)
        {
            var deletedCategoryBlog = await _categoryBlogDAL.GetAsync(I => I.BlogId == categoryBlogAddDTO.BlogId && I.CategoryId == categoryBlogAddDTO.CategoryId);

            if(deletedCategoryBlog != null)
                await _categoryBlogDAL.RemoveAsync(deletedCategoryBlog);

        }

        public async Task<List<Blog>> GetAllWithCategoryIdAsync(int categoryId)
        {
            return await _blogDAL.GetAllWithCategoryIdAsync(categoryId);    
        }

    }
}
