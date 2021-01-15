using Furkan.Furkan_BlogProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.Entities.Concreate
{
    public class Blog : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public DateTime ReleaseTime { get; set; } = DateTime.Now;


        public int AuthorId { get; set; }
        public AppUser Author { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }

        public List<Comment> Comments { get; set; }



    }
}
