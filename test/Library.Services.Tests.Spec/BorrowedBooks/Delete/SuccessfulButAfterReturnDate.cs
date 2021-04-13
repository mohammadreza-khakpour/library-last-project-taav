using FluentAssertions;
using Library.Entities;
using Library.Infrastructure.Application;
using Library.Infrastructure.Test;
using Library.Persistence.EF;
using Library.Persistence.EF.BorrowedBooks;
using Library.Services.BorrowedBooks;
using Library.Services.BorrowedBooks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Library.Services.Tests.Spec.BorrowedBooks.Delete
{
    public class SuccessfulButAfterReturnDate
    {
        private EFInMemoryDatabase db;
        private BorrowedBookRepository efBorrowedBookRepository;
        private UnitOfWork efUnitOfWork;
        private BorrowedBookService sut;
        private EFDataContext context;
        private BorrowedBook borrowedBook;
        private Action actualResultForDelete;
        public SuccessfulButAfterReturnDate()
        {
            db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            efBorrowedBookRepository = new EFBorrowedBookRepository(context);
            efUnitOfWork = new EFUnitOfWork(context);
            sut = new BorrowedBookAppService(efBorrowedBookRepository, efUnitOfWork);
        }
        // Given[("تنها یک کتاب با عنوان راهنمای اشپزی و تاریخ برگشت 13/03/2021
        // در فهرست کتابهای به امانت سپرده شده موجود باشد")]
        private void Given()
        {
            borrowedBook = new BorrowedBook()
            {
                Title = "راهنمای اشپزی",
                ReturnDate = DateTime.Parse("03/13/2021")
            };
            context.Manipulate(_ => _.BorrowedBooks.Add(borrowedBook));
        }
        // When[("کتاب با عنوان راهنمای اشپزی برگردانده میشود")]
        private void When()
        {
            actualResultForDelete = ()=>sut.Delete(borrowedBook.Id);
        }
        // Then[("باید در فهرست کتابهای به امانت سپرده شده، کتابی موجود نباشد
        // و : خطای دیرکرد در بازگرداندن کتاب رخ دهد")]
        private void Then()
        {
            actualResultForDelete.Should().Throw<BorrowedBookReturnedAfterReturnDateException>();
            context.BorrowedBooks.ToList().Should().HaveCount(0);
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
