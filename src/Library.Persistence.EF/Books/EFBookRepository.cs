using Library.Entities;
using Library.Services.Books.Contracts;
using System;
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
    }
}
