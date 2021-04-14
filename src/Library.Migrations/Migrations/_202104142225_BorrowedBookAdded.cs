using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Migrations.Migrations
{
    [Migration(202104142225)]
    public class _202104142225_BorrowedBookAdded : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table("BorrowedBooks");
        }

        public override void Up()
        {
            Create.Table("BorrowedBooks")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50)
                .WithColumn("ReturnDate").AsDateTime();
        }
    }
}
