using FluentAssertions;
using Library.Entities;
using Library.Infrastructure.Application;
using Library.Infrastructure.Test;
using Library.Persistence.EF;
using Library.Persistence.EF.BorrowedBooks;
using Library.Services.BorrowedBooks;
using Library.Services.BorrowedBooks.Contracts;
using Library.Services.BorrowedBooks.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Library.Services.Tests.Spec.BorrowedBooks.Add
{
    public class FailedBecauseInvalidAgeRange
    {
        private EFInMemoryDatabase db;
        private BorrowedBookRepository efBorrowedBookRepository;
        private UnitOfWork efUnitOfWork;
        private BorrowedBookService sut;
        private EFDataContext context;
        private BookCategory bookCategory;
        private Book book;
        private Member member;
        Action actualResult;
        public FailedBecauseInvalidAgeRange()
        {
            db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            efBorrowedBookRepository = new EFBorrowedBookRepository(context);
            efUnitOfWork = new EFUnitOfWork(context);
            sut = new BorrowedBookAppService(efBorrowedBookRepository, efUnitOfWork);
        }
        // Given[("تنها یک کتاب با عنوان فرگشت برای نوجوانان با دسته کتابهای علمی
        // و دسته سنی ده تا بیست در فهرست کتابها موجود باشد
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
                AgeRange = AgeRange.tenToTwenty,
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
        // When[("کتاب با عنوان فرگشت برای نوجوانان  را به عضو با سن 29 سال امانت میدهم")]
        private void When()
        {
            AddBorrowedBookDto dto = new AddBorrowedBookDto()
            {
                BookAgeRange = book.AgeRange,
                BookTitle = book.Title,
            };
            actualResult = () => sut.Add(dto);
        }
        // Then[("باید خطای عدم تطابق دسته سنی رخ دهد")]
        private void Then()
        {
            actualResult.Should().Throw<InvalidAgeRangeToBorrowException>();
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
