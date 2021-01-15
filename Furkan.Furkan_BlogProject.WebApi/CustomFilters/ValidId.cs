using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furkan.Furkan_BlogProject.WebApi.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity:class,ITable,new()
    {
        private readonly IGenericService<TEntity> _genericService;
        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictinory = context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();

            var id = int.Parse(dictinory.Value.ToString());

            var entity = _genericService.FindByIdAsync(id).Result;

            if (entity == null)
                context.Result = new NotFoundObjectResult($"{id} değerine sahip bir nesne bulunamadı");

        }
    }
}
