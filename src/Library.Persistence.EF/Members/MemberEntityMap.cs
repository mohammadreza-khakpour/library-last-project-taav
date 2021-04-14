using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Persistence.EF.Members
{
    class MemberEntityMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Address).IsUnicode().HasMaxLength(100);
            builder.Property(_ => _.Age);
            builder.Property(_ => _.Fullname).IsUnicode().HasMaxLength(50);
        }
    }
}
