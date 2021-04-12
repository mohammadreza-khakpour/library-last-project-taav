using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Books.Contracts
{
    public interface BookService
    {
        int Add(AddBookDto dto);
        int Update(int id, UpdateBookDto dto);
    }
}
