using FluentAssertions;
using Library.Entities;
using Library.Infrastructure.Application;
using Library.Infrastructure.Test;
using Library.Persistence.EF;
using Library.Persistence.EF.Books;
using Library.Persistence.EF.BorrowedBooks;
using Library.Services.Books;
using Library.Services.Books.Contracts;
using Library.Services.BorrowedBooks;
using Library.Services.BorrowedBooks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Library.Services.Tests.Spec.BorrowedBooks.Add
{
    public class Successful
    {
        private EFInMemoryDatabase db;
        private BorrowedBookRepository efBorrowedBookRepository;
        private UnitOfWork efUnitOfWork;
        private BorrowedBookService sut;
        private EFDataContext context;
        private BookCategory bookCategory;
        private Book book;
        private Member member;
        public Successful()
        {
            db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            efBorrowedBookRepository = new EFBorrowedBookRepository(context);
            efUnitOfWork = new EFUnitOfWork(context);
            sut = new BorrowedBookAppService(efBorrowedBookRepository, efUnitOfWork);
        }
        // Given[("تنها یک کتاب با عنوان فرگشت با دسته کتابهای علمی
        // و دسته سنی بیست به بالا در فهرست کتابها موجود باشد
        // و تنها یک عضو با سن 29 سال در فهرست اعضا موجود است")]
        private void Given()
        {
            bookCategory = new BookCategory()
            {
                Title = "کتابهای علمی"
            };
            context.BookCategories.Add(bookCategory);
            context.SaveChanges();
            book = new Book()
            {
                Title = "فرگشت",
                AgeRange = AgeRange.twentyToOlder,
                CategoryId = bookCategory.Id
            };
            context.Books.Add(book);
            member = new Member()
            {
                Age = 29
            };
            context.Books.Add(book);
            context.SaveChanges();
        }
        // When[("کتاب با عنوان فرگشت را به عضو با سن 29 سال امانت میدهم")]
        private void When()
        {
            AddBorrowedBookDto dto = new AddBorrowedBookDto() {
                BookAgeRange = book.AgeRange,
                BookTitle = book.Title,
                MemberAge = member.Age,
                
            };
            sut.Add(dto);
        }
        // Then[("باید تنها یک کتاب با عنوان فرگشت
        // و تاریخ برگشت پس از 14/04/2021 در فهرست کتابهای به امانت داده شده
        // وجود داشته باشد")]
        private void Then()
        {
            var listOfBorrowedBooks = context.BorrowedBooks.ToList();
            listOfBorrowedBooks.Should().HaveCount(1);
            var expected = context.BorrowedBooks.Single(_ => _.Title == book.Title);
            expected.ReturnDate.Should().BeAfter(DateTime.Parse("04/14/2021"));
        }
        [Fact]
        public void Run()
        {
            Given();
            When();
            Then();
        }
    }
}
