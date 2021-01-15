using Furkan.Furkan_BlogProject.DataAccess.Interface;
using Furkan.Furkan_BlogProject.Entities.Concreate;

namespace Furkan.Furkan_BlogProject.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfCommentRepository : EfGenericRepository<Comment> , ICommentDAL
    {
       
    }
}
