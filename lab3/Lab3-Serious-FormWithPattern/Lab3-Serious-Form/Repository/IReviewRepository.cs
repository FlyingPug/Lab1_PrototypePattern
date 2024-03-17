using Lab3_Serious_Form.Entity;

namespace Lab3_Serious_Form.Repository
{
    public interface IReviewRepository
    {
        Task<Review> CreateAsync(Review newReview, CancellationToken cancellationToken);
        Task<List<Review>> GetAllAsync(CancellationToken cancellationToken);
    }
}
