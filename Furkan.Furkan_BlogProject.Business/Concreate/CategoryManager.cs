using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.DataAccess.Interface;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Furkan.Furkan_BlogProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Furkan.Furkan_BlogProject.Business.Concreate
{
    public class CategoryManager : GenericManager<Category> , ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL) : base(categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public async Task<List<Category>> GetAllWithCategoryBlogs()
        {
            return await _categoryDAL.GetAllWithCategoryBlogs();
        }
    }
}
