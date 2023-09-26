
using Microsoft.EntityFrameworkCore;

namespace BookAPI;

public class ReviewRepository : IReviewRepository
{
    private readonly DbSet<Review> _reviews;
    public ICollection<Review> GetBookReviews(int bookId)
    {
        return _reviews
            .Where(r => r.Book.Id == bookId)
            .ToList();
    }

    public Review GetReview(int reviewId)
    {
        return _reviews
            .FirstOrDefault(r => r.Id == reviewId);
    }

    public Book GetReviewBook(int reviewId)
    {
        return _reviews
            .Include(r => r.Book)
            .FirstOrDefault(r => r.Id == reviewId)  // Review
            .Book;                                  // Review.Book

        /*
        DB
        {
            "id": 1,
            "headline": "bla bla",
            ...
            "bookId": 1 // <- DB nie moze miec zagniezdzonego obiektu
        }

        .NET
        {
            "id": 1,
            "headline": "bla bla",
            ...
            "book": {
                "id": 1,
                "title": "bla title",
                "datePublished": "1903-01-01T00:00:00Z
            }
        }
        */
    }

    public ICollection<Review> GetReviews()
    {
        return _reviews
            .ToList();
    }

    public bool ReviewExists(int reviewId)
    {
        return _reviews
         .Any(r => r.Id == reviewId);
    }
}
