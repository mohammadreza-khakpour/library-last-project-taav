using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Tests.Unit.BorrowedBooks
{
    static class BorrowedBookFactory
    {
        public static BookCategory GenerateDummyBookCategory()
        {
            BookCategory category = new BookCategory()
            {
                Title = "dummy-category-title",
            };
            return category;
        }
        public static Writer GenerateDummyWriter()
        {
            Writer writer = new Writer()
            {
                Code = "dummy-writer-code"
            };
            return writer;
        }
        public static Book GenerateDummyBook()
        {
            Book book = new Book()
            {
                Title = "dummy-book-title",
                AgeRange = AgeRange.oneToTen
            };
            return book;
        }
        public static Member GenerateDummyMember()
        {
            Member member = new Member()
            {
                Fullname = "dummy-member-name",
                Age = 9,
                Address = "dummy-member-address"
            };
            return member;
        }
    }
}
