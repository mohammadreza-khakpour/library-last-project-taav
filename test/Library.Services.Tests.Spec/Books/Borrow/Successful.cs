using FluentAssertions;
using Library.Entities;
using Library.Infrastructure.Application;
using Library.Infrastructure.Test;
using Library.Persistence.EF;
using Library.Persistence.EF.Books;
using Library.Services.Books;
using Library.Services.Books.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Library.Services.Tests.Spec.Books.Borrow
{
    public class Successful
    {
        private EFInMemoryDatabase db;
        private BookRepository efBookRepository;
        private UnitOfWork efUnitOfWork;
        private BookService sut;
        private EFDataContext context;
        private BookCategory bookCategory;
        private Book book;
        private int actualRecordId;
        public Successful()
        {
            db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            efBookRepository = new EFBookRepository(context);
            efUnitOfWork = new EFUnitOfWork(context);
            sut = new BookAppService(efBookRepository, efUnitOfWork);
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
            book = new Book() { 
                Title = "فرگشت",
                AgeRange = AgeRange.twentyToOlder,
                CategoryId = bookCategory.Id
            };
            context.Books.Add(book);
            var member = new Member() { 
                Age =29
            };
            context.Books.Add(book);
            context.SaveChanges();
        }
        // When[("کتاب با عنوان فرگشت را به عضو با سن 29 سال امانت میدهم")]
        private void When()
        {
            sut.BorrowBook(book.Id);
        }
        // Then[("باید تنها یک کتاب با عنوان فرگشت
        // و تاریخ برگشت 2021/02/02 در فهرست کتابهای به امانت داده شده  وجود داشته باشد")]
        private void Then()
        {
            var listOfBorrowedBooks = context.BorrowedBooks.ToList();
            listOfBorrowedBooks.Should().HaveCount(1);
            var expected = context.BorrowedBooks.Single(_=>_.Title==book.Title);
            expected.ReturnDate.Should().Be(DateTime.Parse("02/02/2021"));
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
