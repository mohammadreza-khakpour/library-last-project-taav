using FluentAssertions;
using Library.Infrastructure.Application;
using Library.Infrastructure.Test;
using Library.Persistence.EF;
using Library.Persistence.EF.BookCategories;
using Library.Services.BookCategories;
using Library.Services.BookCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Library.Services.Tests.Unit.BookCategories
{
    public class BookCategoryServiceTests
    {
        private BookCategoryService sut;
        private BookCategoryRepository _bookCategoryRepository;
        private UnitOfWork _unitOfWork;
        private EFDataContext context;
        private EFDataContext readContext;
        public BookCategoryServiceTests()
        {
            var db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            readContext = db.CreateDataContext<EFDataContext>();
            _bookCategoryRepository = new EFBookCategoryRepository(context);
            _unitOfWork = new EFUnitOfWork(context);
            sut = new BookCategoryAppService(_bookCategoryRepository,_unitOfWork);
        }
        [Fact]
        public void Add_add_book_category_properly()
        {
            //Arrange
            AddBookCategoryDto dto = new AddBookCategoryDto() { 
                Title = "dummy-title",
            };

            //Act
            var actualReturnedId = sut.Add(dto);

            //Assert
            var expected = readContext.BookCategories.Single(_ => _.Id == actualReturnedId);
            expected.Title.Should().Be("dummy-title");
        }
    }
}
