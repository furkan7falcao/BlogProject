using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.DataAccess.Interface;
using Furkan.Furkan_BlogProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Furkan.Furkan_BlogProject.Business.Concreate
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericDAL<TEntity> _genericDAL;
        public GenericManager(IGenericDAL<TEntity> genericDAL)
        {
            _genericDAL = genericDAL;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _genericDAL.AddAsync(entity);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _genericDAL.FindByIdAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericDAL.GetAllAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _genericDAL.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDAL.UpdateAsync(entity);
        }
    }
}
