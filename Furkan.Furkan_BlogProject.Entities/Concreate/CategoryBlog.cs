using Furkan.Furkan_BlogProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.Entities.Concreate
{
    public class CategoryBlog : ITable
    {
        public int Id { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
