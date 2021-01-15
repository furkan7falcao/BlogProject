using Furkan.Furkan_BlogProject.Entities.Interfaces;
using System.Collections.Generic;

namespace Furkan.Furkan_BlogProject.Entities.Concreate
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }



        public List<Blog> Blogs { get; set; }

    }
}
