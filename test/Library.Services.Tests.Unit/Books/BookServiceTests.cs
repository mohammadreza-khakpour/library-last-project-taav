using FluentAssertions;
using Library.Entities;
using Library.Infrastructure.Application;
using Library.Infrastructure.Test;
using Library.Persistence.EF;
using Library.Persistence.EF.Books;
using Library.Services.BookCategories.Contracts;
using Library.Services.Books;
using Library.Services.Books.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Library.Services.Tests.Unit.Books
{
    public class BookServiceTests
    {
        private BookService sut;
        private BookRepository _bookRepository;
        private UnitOfWork _unitOfWork;
        private EFDataContext context;
        private EFDataContext readContext;
        public BookServiceTests()
        {
            var db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            readContext = db.CreateDataContext<EFDataContext>();
            _bookRepository = new EFBookRepository(context);
            _unitOfWork = new EFUnitOfWork(context);
            sut = new BookAppService(_bookRepository, _unitOfWork);
        }
        [Fact]
        public void Add_add_book_properly()
        {
            //Arrange
            BookCategory category = new BookCategory()
            {
                Title = "dummy-title",
            };
            context.Manipulate(_=>_.BookCategories.Add(category));
            AddBookDto dto = new AddBookDto()
            {
                Title = "dummy-title",
                AgeRange = AgeRange.oneToTen,
                CategoryId = category.Id,
            };

            //Act
            int actualReturnedId = sut.Add(dto);

            //Assert
            var expected = readContext.Books.Single(_ => _.Id == actualReturnedId);
            expected.Title.Should().Be(dto.Title);
            expected.AgeRange.Should().Be(dto.AgeRange);
            expected.CategoryId.Should().Be(dto.CategoryId);
        }
        [Fact]
        public void Update_update_book_properly()
        {
            //Arrange
            BookCategory category = new BookCategory()
            {
                Title = "dummy-category-title",
            };
            context.Manipulate(_ => _.BookCategories.Add(category));
            Book book = new Book() {
                Title = "dummy-title",
                AgeRange = AgeRange.oneToTen,
                CategoryId = category.Id,
            };
            context.Manipulate(_ => _.Books.Add(book));
            UpdateBookDto dto = new UpdateBookDto()
            {
                Title = "dummy-book-title",
                AgeRange = AgeRange.oneToTen,
                CategoryId = category.Id,
            };

            //Act
            int actualReturnedId = sut.Update(book.Id,dto);

            //Assert
            var expected = readContext.Books.Single(_=>_.Id==actualReturnedId);
            expected.Title.Should().Be(dto.Title);
            expected.AgeRange.Should().Be(dto.AgeRange);
            expected.CategoryId.Should().Be(dto.CategoryId);
        }
    }
}
