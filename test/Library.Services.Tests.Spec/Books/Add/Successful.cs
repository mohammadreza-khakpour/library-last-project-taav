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

namespace Library.Services.Tests.Spec.Books.Add
{
    public class Successful
    {
        private EFInMemoryDatabase db;
        private BookRepository efBookRepository;
        private UnitOfWork efUnitOfWork;
        private BookService sut;
        private EFDataContext context;
        private BookCategory bookCategory;
        private int actualRecordId;
        public Successful()
        {
            db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            efBookRepository = new EFBookRepository(context);
            efUnitOfWork = new EFUnitOfWork(context);
            sut = new BookAppService(efBookRepository, efUnitOfWork);
        }
        // Given[("یک دسته بندی  کتاب های رمان در لیست دسته بندی کتابها وجود دارد")]
        private void Given()
        {
            bookCategory = new BookCategory() { 
                Title = "کتابهای رمان"
            };
            context.BookCategories.Add(bookCategory);
            context.SaveChanges();
        }
        // When[("یک کتاب با عنوان شازده کوچولو با،  دسته سنی  بیست به بالا
        // و دسته بندی کتاب های رمان تعریف میکنم")]
        private void When()
        {
            
            AddBookDto dto = new AddBookDto() {
                Title = "شازده کوچولو",
                AgeRange = AgeRange.twentyToOlder,
                CategoryId = bookCategory.Id
            };
            actualRecordId = sut.Add(dto);
        }
        // Then[("باید فقط یک کتاب با عنوان شازده کوچولو با
        // دسته سنی  بیست به بالا و دسته بندی کتاب های رمان  در فهرست کتابها وجود داشته باشد")]
        private void Then()
        {
            var listOfBooks = context.Books.ToList();
            listOfBooks.Should().HaveCount(1);
            var expected = context.Books.Single(_ => _.Id == actualRecordId);
            expected.Title.Should().Be("شازده کوچولو");
            expected.AgeRange.Should().Be(AgeRange.twentyToOlder);
            expected.Category.Title.Should().Be(bookCategory.Title);
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
