namespace BookAPI;

public class CategoryRepository : ICategoryRepository
{
    private readonly BookDbContext _context;

    public CategoryRepository(BookDbContext context)
    {
        _context = context;
    }

    public bool CategoryExists(int id)
    {
        return _context.Categories
            .Any(c => c.Id == id);
    }

    public ICollection<Category> GetBookCategories(int bookId)
    {
        return _context.Categories
            .Where(c => c.BookCategories.Any(bc => bc.BookId == bookId))
            .ToList();
    }

    public ICollection<Category> GetCategories()
    {
        return _context.Categories
            .ToList();
    }

    public Category GetCategory(int id)
    {
        return _context.Categories
            .FirstOrDefault(c => c.Id == id);
    }

    public ICollection<Book> GetCategoryBooks(int categoryId)
    {
        return _context.Books
            .Where(b => b.BookCategories.Any(bc => bc.CategoryId == categoryId))
            .ToList();
    }
}
