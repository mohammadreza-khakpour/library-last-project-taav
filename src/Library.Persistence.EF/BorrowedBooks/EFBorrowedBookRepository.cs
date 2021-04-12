using Library.Entities;
using Library.Services.BorrowedBooks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Persistence.EF.BorrowedBooks
{
    public class EFBorrowedBookRepository : BorrowedBookRepository
    {
        private EFDataContext _dBContext;
        public EFBorrowedBookRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void Add(string title)
        {
            var borrowedBook = new BorrowedBook() { 
                Title = title,
                ReturnDate = DateTime.Parse("02/02/2021")
            };
            _dBContext.BorrowedBooks.Add(borrowedBook);
        }

        public Book FindById(int bookId)
        {
            return _dBContext.Books.Find(bookId);
        }
    }
}
