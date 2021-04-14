using FluentAssertions;
using Library.Entities;
using Library.Infrastructure.Application;
using Library.Infrastructure.Test;
using Library.Persistence.EF;
using Library.Persistence.EF.BorrowedBooks;
using Library.Services.BorrowedBooks;
using Library.Services.BorrowedBooks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Library.Services.Tests.Unit.BorrowedBooks
{
    public class BorrowedBookServiceTests
    {
        private BorrowedBookService sut;
        private BorrowedBookRepository _borrowedBookRepository;
        private UnitOfWork _unitOfWork;
        private EFDataContext context;
        private EFDataContext readContext;
        public BorrowedBookServiceTests()
        {
            var db = new EFInMemoryDatabase();
            context = db.CreateDataContext<EFDataContext>();
            readContext = db.CreateDataContext<EFDataContext>();
            _borrowedBookRepository = new EFBorrowedBookRepository(context);
            _unitOfWork = new EFUnitOfWork(context);
            sut = new BorrowedBookAppService(_borrowedBookRepository, _unitOfWork);
        }
        [Fact]
        public void Add_add_borrowed_book_properly()
        {
            //Arrange
            BookCategory category = BorrowedBookFactory.GenerateDummyBookCategory();
            context.Manipulate(_ => _.BookCategories.Add(category));
            Writer writer = BorrowedBookFactory.GenerateDummyWriter();
            context.Manipulate(_ => _.Writers.Add(writer));
            Book book = BorrowedBookFactory.GenerateDummyBook();
            book.CategoryId = category.Id;
            book.WriterId = writer.Id;
            context.Manipulate(_ => _.Books.Add(book));
            Member member = BorrowedBookFactory.GenerateDummyMember();
            context.Manipulate(_ => _.Members.Add(member));
            AddBorrowedBookDto dto = new AddBorrowedBookDto() { 
                MemberAge = member.Age,
                BookTitle = book.Title,
                BookAgeRange = book.AgeRange,
            };

            //Act
            sut.Add(dto);

            //Assert
            var expected = readContext.BorrowedBooks.Single(_ => _.Title == dto.BookTitle);
            expected.Title.Should().Be(dto.BookTitle);
            expected.ReturnDate.Should().BeAfter(DateTime.Now);
        }
        [Fact]
        public void Delete_delete_borrowed_book_properly()
        {
            //Arrange
            BookCategory category = BorrowedBookFactory.GenerateDummyBookCategory();
            context.Manipulate(_ => _.BookCategories.Add(category));
            Writer writer = BorrowedBookFactory.GenerateDummyWriter();
            context.Manipulate(_ => _.Writers.Add(writer));
            Book book = BorrowedBookFactory.GenerateDummyBook();
            book.CategoryId = category.Id;
            book.WriterId = writer.Id;
            context.Manipulate(_ => _.Books.Add(book));
            Member member = BorrowedBookFactory.GenerateDummyMember();
            context.Manipulate(_ => _.Members.Add(member));
            BorrowedBook borrowedBook = new BorrowedBook()
            {
                Title = book.Title,
                ReturnDate = DateTime.Parse("02/02/2022")
            };
            context.Manipulate(_=>_.BorrowedBooks.Add(borrowedBook));

            //Act
            sut.Delete(borrowedBook.Id);

            //Assert
            var expected = readContext.BorrowedBooks.FirstOrDefault(_ => _.Id == borrowedBook.Id);
            expected.Should().BeNull();

        }
    }
}
