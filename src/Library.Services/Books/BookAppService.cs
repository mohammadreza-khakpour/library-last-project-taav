using Library.Entities;
using Library.Infrastructure.Application;
using Library.Services.Books.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Books
{
    public class BookAppService : BookService
    {
        private readonly BookRepository _bookRepository;
        private readonly UnitOfWork _unitOfWork;
        public BookAppService(BookRepository bookRepository,
                                      UnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddBookDto dto)
        {
            Book book = new Book()
            {
                Title = dto.Title,
                AgeRange = dto.AgeRange,
                CategoryId = dto.CategoryId,
                WriterId = dto.WriterId
            };
            _bookRepository.Add(book);
            _unitOfWork.Complete();
            return book.Id;
        }

        public int Update(int id, UpdateBookDto dto)
        {
            Book theBook = _bookRepository.FindById(id);
            theBook.Title = dto.Title;
            _unitOfWork.Complete();
            return theBook.Id;
        }
    }
}
