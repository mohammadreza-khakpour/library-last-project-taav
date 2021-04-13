using Library.Entities;

namespace Library.Services.BorrowedBooks
{
    public interface BorrowedBookRepository
    {
        BorrowedBook FindById(int bookId);
        void Add(string title);
        void Delete(BorrowedBook borrowedBook);
    }
}