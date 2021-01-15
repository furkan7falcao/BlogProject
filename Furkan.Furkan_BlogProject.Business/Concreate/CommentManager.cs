using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.DataAccess.Interface;
using Furkan.Furkan_BlogProject.Entities.Concreate;

namespace Furkan.Furkan_BlogProject.Business.Concreate
{
    public class CommentManager : GenericManager<Comment> , ICommentService
    {
        private readonly ICommentDAL _commentDAL;
        public CommentManager(ICommentDAL commentDAL) : base(commentDAL)
        {
            _commentDAL = commentDAL;
        }
       
        
    }
}
