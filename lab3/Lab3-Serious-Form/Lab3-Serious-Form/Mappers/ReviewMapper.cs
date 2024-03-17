using Lab3_Serious_Form.Entity;
using Lab3_Serious_Form.Models;

namespace Lab3_Serious_Form.Mappers
{
    public class ReviewMapper
    {
        internal static ReviewModel? Map(Review review)
        {
            return new ReviewModel(review.Name, review.Email, review.Message, review.PhoneNumber);
        }
    }
}
