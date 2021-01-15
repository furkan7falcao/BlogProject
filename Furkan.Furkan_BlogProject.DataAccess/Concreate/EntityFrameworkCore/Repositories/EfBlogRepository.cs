using Furkan.Furkan_BlogProject.DataAccess.Concreate.EntityFrameworkCore.Context;
using Furkan.Furkan_BlogProject.DataAccess.Interface;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Furkan.Furkan_BlogProject.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Furkan.Furkan_BlogProject.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogDAL
    {
        public async Task<List<Blog>> GetAllWithCategoryIdAsync(int categoryId)
        {
            using var context = new ApplicationDbContext();

            return await context.Blog.Join(context.CategoryBlog, blogTable => blogTable.Id, categoryBlogTable => categoryBlogTable.BlogId, (blog, categoryBlog) => new
            {
                blog = blog,
                categoryBlog = categoryBlog
            }).Where(I => I.categoryBlog.CategoryId == categoryId).Select(I => new Blog
            {
                Author = I.blog.Author,
                AuthorId = I.blog.AuthorId,
                CategoryBlogs = I.blog.CategoryBlogs,
                Content = I.blog.Content,
                ImagePath = I.blog.ImagePath,
                ReleaseTime = I.blog.ReleaseTime,
                ShortDescription = I.blog.ShortDescription,
                Title = I.blog.Title,
                Comments = I.blog.Comments,
                Id = I.blog.Id
            }).ToListAsync();

        }


    }
}
