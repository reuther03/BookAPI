using BookAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BookAPI;

public class AuthorRepository : IAuthorRepository
{
    private readonly DbSet<Author> _authors;

    public AuthorRepository(BookDbContext context)
    {
        _authors = context.Authors;
    }
    public bool AuthorExists(int id)
    {
        return _authors
            .Any(a => a.Id == id);
    }

    public Author GetAuthor(int id)
    {
        return _authors
            .FirstOrDefault(a => a.Id == id);
    }

    public ICollection<Book> GetAuthorBooks(int authorId)
    {
        return _authors
            .Include(a => a.BookAuthors).ThenInclude(ba => ba.Book)
            .Where(a => a.Id == authorId)
            .SelectMany(a => a.BookAuthors)
            .Select(ba => ba.Book)
            .ToList();

        /* SelectMany
        BA1:
            Book1
            Book2
        BA2:
            Book3
            Book4
        */

        /* Select
        Book1
        Book2
        Book3
        Book4
        */
    }

    public ICollection<Author> GetAuthors()
    {
       return _authors
        .ToList();
    }

    public ICollection<Author> GetBookAuthors(int bookId)
    {
        return _authors
            .Include(a => a.BookAuthors)
            .Where(a => a.BookAuthors.Any(ba => ba.BookId == bookId))
            .SelectMany(a => a.BookAuthors)
            .Select(ba => ba.Author)
            .ToList();
    }
}
