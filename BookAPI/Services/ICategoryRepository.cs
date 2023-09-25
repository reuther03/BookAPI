namespace BookAPI;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Category> GetBookCategories(int bookId);
    ICollection<Book> GetCategoryBooks(int categoryId);
    bool CategoryExists(int id);
}