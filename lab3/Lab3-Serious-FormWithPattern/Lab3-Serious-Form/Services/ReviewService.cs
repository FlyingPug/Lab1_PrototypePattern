using Lab3_Serious_Form.Entity;
using Lab3_Serious_Form.Exceptions;
using Lab3_Serious_Form.Repository;

namespace Lab3_Serious_Form.Services
{
    public class ReviewService : IReviewService
    {
        IReviewRepository reviewRepository;

        public ReviewService(IReviewRepository _reviewRepository)
        {
            reviewRepository = _reviewRepository;
        }

        public async Task<Review> CreateAsync(CreateReviewRequest request, CancellationToken cancellationToken)
        {
            /*if (string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Message) ||
                string.IsNullOrWhiteSpace(request.PhoneNumber) ||
                string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentIsRequiredException("Отсутствует необходимое поле");
            }*/

            var newReview = new Review
            {
                Message = request.Message,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            return await reviewRepository.CreateAsync(newReview, cancellationToken);;
        }

        public Task<List<Review>> GetAllAsync(CancellationToken cancellationToken)
        {
            return reviewRepository.GetAllAsync(cancellationToken);
        }
    }
}
