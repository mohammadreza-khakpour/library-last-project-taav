using Library.Entities;
using Library.Services.Books.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Library.Persistence.EF.Books
{
    public class EFBookRepository : BookRepository
    {
        private EFDataContext _dBContext;
        public EFBookRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void Add(Book book)
        {
            _dBContext.Books.Add(book);
        }

        public void BorrowBook(string bookTitle)
        {
            BorrowedBook borrowedBook = new BorrowedBook() {
                Title = bookTitle,
                ReturnDate = DateTime.Parse("02/02/2021")
            };
            _dBContext.BorrowedBooks.Add(borrowedBook);
        }

        public Book FindById(int id)
        {
            return _dBContext.Books.FirstOrDefault(_=>_.Id==id);
        }
    }
}
