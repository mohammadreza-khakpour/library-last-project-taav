using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Migrations.Migrations
{
    [Migration(202104142150)]
    public class _202104142150_InitiallyBookCategoryAndWriterAdded : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table("Writers");
            Delete.Table("BookCategories");
        }

        public override void Up()
        {
            Create.Table("BookCategories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50);
            Create.Table("Writers")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Code").AsString(10);
        }
    }
}
