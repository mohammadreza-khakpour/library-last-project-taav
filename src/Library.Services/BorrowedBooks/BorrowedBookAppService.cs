using Library.Infrastructure.Application;
using Library.Services.Books.Contracts;
using Library.Services.BorrowedBooks.Contracts;
using Library.Services.BorrowedBooks.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.BorrowedBooks
{
    public class BorrowedBookAppService : BorrowedBookService
    {
        private readonly BorrowedBookRepository _borrowedBookRepository;
        private readonly UnitOfWork _unitOfWork;
        public BorrowedBookAppService(BorrowedBookRepository borrowedBookRepository,
                                      UnitOfWork unitOfWork)
        {
            _borrowedBookRepository = borrowedBookRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddBorrowedBookDto dto)
        {
            if (dto.BookAgeRange != dto.MemberAgeRange)
            {
                throw new InvalidAgeRangeToBorrowException();
            }
            _borrowedBookRepository.Add(dto.BookTitle);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            var theBorrowedBook = _borrowedBookRepository.FindById(id);
            int compareDatesResult = theBorrowedBook.ReturnDate.CompareTo(DateTime.Now);
            _borrowedBookRepository.Delete(theBorrowedBook);
            _unitOfWork.Complete();
            if (compareDatesResult<0)
            {
                throw new BorrowedBookReturnedAfterReturnDateException();
            }
        }
    }
}
