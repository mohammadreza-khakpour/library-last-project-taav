using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Persistence.EF.BookCategories
{
    class BookCategoryEntityMap : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Title).IsUnicode().HasMaxLength(50);
        }
    }
}
