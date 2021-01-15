using Microsoft.AspNetCore.Http;

namespace Furkan.Furkan_BlogProject.WebApi.Models
{
    public class BlogAddModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
        public int AuthorId { get; set; }

    }
}
