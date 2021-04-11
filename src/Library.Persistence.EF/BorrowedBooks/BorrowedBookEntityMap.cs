using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Persistence.EF.BorrowedBooks
{
    class BorrowedBookEntityMap : IEntityTypeConfiguration<BorrowedBook>
    {
        public void Configure(EntityTypeBuilder<BorrowedBook> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_=>_.Title).IsUnicode().HasMaxLength(50);
            builder.Property(_ => _.ReturnDate);
        }
    }
}
