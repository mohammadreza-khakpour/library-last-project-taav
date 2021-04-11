using Library.Entities;
using Library.Services.BookCategories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Persistence.EF.BookCategories
{
    public class EFBookCategoryRepository : BookCategoryRepository
    {
        private EFDataContext _dBContext;
        public EFBookCategoryRepository(EFDataContext dBContext)
        {
            _dBContext = dBContext;
        }
        public void Add(BookCategory bookCategory)
        {
            _dBContext.BookCategories.Add(bookCategory);
        }
    }
}
