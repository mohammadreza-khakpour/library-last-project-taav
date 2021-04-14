using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Persistence.EF.Books
{
    class BookEntityMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(_=>_.Id);
            builder.Property(_=>_.Title).IsUnicode().HasMaxLength(50);
            builder.Property(_ => _.AgeRange);
            builder.HasOne(_ => _.Category);
            builder.HasOne(_ => _.Writer);
        }
    }
}
