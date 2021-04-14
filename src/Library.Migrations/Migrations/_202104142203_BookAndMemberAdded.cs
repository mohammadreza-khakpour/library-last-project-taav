using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Migrations.Migrations
{
    [Migration(202104142203)]
    public class _202104142203_BookAndMemberAdded : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_Books_BookCategories").OnTable("Books");
            Delete.ForeignKey("FK_Books_Writers").OnTable("Books");
            Delete.Table("Books");
            Delete.Table("Members");
        }

        public override void Up()
        {
            Create.Table("Books")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50)
                .WithColumn("AgeRange").AsInt32()
                .WithColumn("CategoryId").AsInt32()
                .ForeignKey("FK_Books_BookCategories", "BookCategories", "Id")
                .OnDelete(System.Data.Rule.Cascade)
                .WithColumn("WriterId").AsInt32().Nullable()
                .ForeignKey("FK_Books_Writers", "Writers", "Id")
                .OnDelete(System.Data.Rule.Cascade);
            Create.Table("Members")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Address").AsString(100)
                .WithColumn("Age").AsByte()
                .WithColumn("Fullname").AsString(50);
        }
    }
}
