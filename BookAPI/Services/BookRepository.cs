using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly DbSet<Book> _books;

        public BookRepository(BookDbContext context)
        {
            _books = context.Books;
        }

        public Book GetBook(int bookId)
        {
            return _books
                .FirstOrDefault(b => b.Id == bookId);
        }

        public double GetBookRating(int bookId)
        {
            return _books
                .Where(b => b.Id == bookId)
                .SelectMany(b => b.Reviews)
                .Select(r => r.Rating)
                .Average();
        }

        public ICollection<Book> GetBooks()
        {
            return _books
                .ToList();
        }

        public bool IsDuplicateIsbn(int bookId)
        {
            var book = _books
                .FirstOrDefault(b => b.Id == bookId);

            return _books
                .Any(b => b.Id != book.Id &&
                          b.Isbn == book.Isbn);
        }
    }
}