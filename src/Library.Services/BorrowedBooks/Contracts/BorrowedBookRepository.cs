using Library.Entities;

namespace Library.Services.BorrowedBooks
{
    public interface BorrowedBookRepository
    {
        Book FindById(int bookId);
        void Add(string title);
    }
}