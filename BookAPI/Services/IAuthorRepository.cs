using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        Author GetAuthor(int id);
        ICollection<Author> GetBookAuthors(int bookId);
        ICollection<Book> GetAuthorBooks(int authorId);
        bool AuthorExists(int id);
    }
}