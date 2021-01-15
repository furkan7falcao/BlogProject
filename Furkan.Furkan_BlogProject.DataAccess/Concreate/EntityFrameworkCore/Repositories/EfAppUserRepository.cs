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
    public class EfAppUserRepository : EfGenericRepository<AppUser> , IAppUserDAL
    {
       
    }
}
