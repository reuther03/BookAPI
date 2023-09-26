
using Microsoft.EntityFrameworkCore;

namespace BookAPI;

public class ReviewRepository : IReviewRepository
{
    private readonly DbSet<Review> _reviews;
    public ICollection<Review> GetBookReviews(int bookId)
    {
        throw new NotImplementedException();
    }

    public Review GetReview(int reviewId)
    {
        throw new NotImplementedException();
    }

    public Book GetReviewBook(int reviewId)
    {
        throw new NotImplementedException();
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
