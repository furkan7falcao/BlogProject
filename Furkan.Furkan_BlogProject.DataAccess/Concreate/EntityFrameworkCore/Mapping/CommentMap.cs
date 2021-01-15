using Furkan.Furkan_BlogProject.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Furkan.Furkan_BlogProject.DataAccess.Concreate.EntityFrameworkCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.AuthorName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.AuthorEmail).HasMaxLength(100);
            builder.Property(I => I.Remark).HasColumnType("ntext").IsRequired();
            builder.Property(I => I.PostedTime).IsRequired();

            builder.HasOne(I => I.ParentComment).WithMany(I => I.SubComments).HasForeignKey(I => I.ParentCommentId);
        }
    }
}
