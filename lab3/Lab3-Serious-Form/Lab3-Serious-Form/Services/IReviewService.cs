using Lab3_Serious_Form.Entity;

namespace Lab3_Serious_Form.Services
{
    public interface IReviewService
    {
        Task<Review> CreateAsync(CreateReviewRequest request, CancellationToken cancellationToken);
        Task<List<Review>> GetAllAsync(CancellationToken cancellationToken);
    }
}
