using Furkan.Furkan_BlogProject.DataAccess.Concreate.EntityFrameworkCore.Mapping;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.DataAccess.Concreate.EntityFrameworkCore.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-AQV5FJM; database = Furkan_BlogProject; integrated security = true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CategoryBlogMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Category> Category { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CategoryBlog> CategoryBlog { get; set; }
        public DbSet<AppUser> AppUser { get; set; }


    }
}
