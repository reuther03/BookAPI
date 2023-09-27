using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services;

public interface IBookRepository
{
    double GetBookRating(int bookId);
    ICollection<Book> GetBooks();
    Book GetBook(int bookId);
    bool IsDuplicateIsbn(int bookId);
}
