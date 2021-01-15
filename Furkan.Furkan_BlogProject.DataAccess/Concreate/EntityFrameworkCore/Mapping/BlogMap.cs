using Furkan.Furkan_BlogProject.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.DataAccess.Concreate.EntityFrameworkCore.Mapping
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).HasMaxLength(100).IsRequired();
            builder.Property(I => I.ShortDescription).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Content).HasColumnType("ntext");
            builder.Property(I => I.ImagePath).HasMaxLength(300);

            builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Blog).HasForeignKey(I => I.BlogId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(I => I.Comments).WithOne(I => I.Blog).HasForeignKey(I => I.BlogId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(I => I.Author).WithMany(I => I.Blogs).HasForeignKey(I => I.AuthorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
