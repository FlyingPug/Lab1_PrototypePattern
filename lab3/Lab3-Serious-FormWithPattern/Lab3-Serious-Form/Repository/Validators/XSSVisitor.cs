using Ganss.Xss;
using Lab3_Serious_Form.Entity;

namespace Lab3_Serious_Form.Repository.Validators
{
    public class XSSVisitor: IVisitor
    {
        private readonly HtmlSanitizer sanitizer;

        public XSSVisitor()
        {
            sanitizer = new HtmlSanitizer();
        }

        public void CheckReview(Review review)
        {
            review.Name = sanitizer.Sanitize(review.Name);
            review.Email = sanitizer.Sanitize(review.Email);
            review.Message = sanitizer.Sanitize(review.Message);
            review.PhoneNumber = sanitizer.Sanitize(review.PhoneNumber);
        }
    }
}
