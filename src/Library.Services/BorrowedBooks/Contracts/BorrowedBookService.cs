using Library.Services.BorrowedBooks.Contracts;

namespace Library.Services.BorrowedBooks
{
    public interface BorrowedBookService
    {
        void Add(AddBorrowedBookDto dto);
    }
}