
using Microsoft.EntityFrameworkCore;

namespace BookAPI;

public class ReviewerRepository : IReviewerRepository
{
    private readonly DbSet<Reviewer> _reviewers;

    public ReviewerRepository(BookDbContext context)
    {
        _reviewers = context.Reviewers;
    }
    public Reviewer GetReviewer(int id)
    {
        return _reviewers
            .FirstOrDefault(r => r.Id == id);
    }

    public ICollection<Reviewer> GetReviewers()
    {
        return _reviewers
            .OrderBy(r => r.FirstName)
            .ToList();
    }

    public ICollection<Review> GetReviewerReviews(int reviewerId)
    {
        return _reviewers
             .Where(r => r.Id == reviewerId)
             .SelectMany(r => r.Reviews)
             .ToList();

        /*
        SelectMany
        [R1, R2, R3]

        Select
        [[R1], [R2], [R3]]
        */
    }

    public Reviewer GetReviewReviewer(int reviewId)
    {
        return _reviewers
            .FirstOrDefault(r => r.Reviews.Any(r => r.Id == reviewId));
    }

    public bool ReviewerExists(int id)
    {
        return _reviewers
            .Any(r => r.Id == id);
    }
}
