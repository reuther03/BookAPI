namespace BookAPI;

public interface IReviewerRepository
{
    ICollection<Reviewer> GetReviewers();
    Reviewer GetReviewer(int id);
    ICollection<Review> GetReviewerReviews(int reviewerId);
    Reviewer GetReviewReviewer(int reviewId);
    bool ReviewerExists(int id);
}
