using Library.Entities;
using Library.Infrastructure.Application;
using Library.Services.BookCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.BookCategories
{
    public class BookCategoryAppService : BookCategoryService
    {
        private readonly BookCategoryRepository _bookCategoryRepository;
        private readonly UnitOfWork _unitOfWork;
        public BookCategoryAppService(BookCategoryRepository bookCategoryRepository,
                                      UnitOfWork unitOfWork)
        {
            _bookCategoryRepository = bookCategoryRepository;
            _unitOfWork = unitOfWork;
        }
        public int Add(AddBookCategoryDto dto)
        {
            BookCategory bookCategory = new BookCategory() {
                Title = dto.Title
            };
            _bookCategoryRepository.Add(bookCategory);
            _unitOfWork.Complete();
            return bookCategory.Id;
        }
    }
}
