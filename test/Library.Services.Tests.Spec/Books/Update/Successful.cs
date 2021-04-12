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

namespace Library.Services.Tests.Spec.Books.Update
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
        // Given[("یک دسته بندی  کتاب های تاریخی در لیست دسته بندی کتابها وجود دارد.
        // و تنها یک کتاب با عنوان جنگ جهانی دوم  با،
        // دسته بندی کتاب های تاریخی در فهرست کتابها وجود دارد")]
        private void Given()
        {
            bookCategory = new BookCategory()
            {
                Title = "کتابهای تاریخی"
            };
            context.BookCategories.Add(bookCategory);
            book = new Book() { 
                Title = "جنگ جهانی دوم",
                Category = bookCategory,
            };
            context.Books.Add(book);
            context.SaveChanges();
        }
        // When[("مشخصات کتاب با عنوان جنگ جهانی دوم را به، عنوان خلاصه جنگ جهانی دوم تغییر میدهم")]
        private void When()
        {
            UpdateBookDto dto = new UpdateBookDto()
            {
                Title = "خلاصه جنگ جهانی دوم",
            };
            actualRecordId = sut.Update(book.Id,dto);
        }
        // Then[("باید فقط یک کتاب با عنوان خلاصه جنگ جهانی دوم
        // و دسته بندی کتاب های تاریخی در فهرست کتابها وجود داشته باشد")]
        //
        private void Then()
        {
            var listOfBooks = context.Books.ToList();
            listOfBooks.Should().HaveCount(1);
            var expected = context.Books.Single(_ => _.Id == actualRecordId);
            expected.Title.Should().Be("خلاصه جنگ جهانی دوم");
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
