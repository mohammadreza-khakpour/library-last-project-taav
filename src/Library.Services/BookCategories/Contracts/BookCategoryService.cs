using Library.Services.BookCategories.Contracts;

namespace Library.Services.BookCategories
{
    public interface BookCategoryService
    {
        int Add(AddBookCategoryDto dto);
    }
}