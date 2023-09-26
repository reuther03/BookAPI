namespace BookAPI;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();
    Review GetReview(int reviewId);
    ICollection<Review> GetBookReviews(int bookId);
    Book GetReviewBook(int reviewId);
    bool ReviewExists(int reviewId);

}
