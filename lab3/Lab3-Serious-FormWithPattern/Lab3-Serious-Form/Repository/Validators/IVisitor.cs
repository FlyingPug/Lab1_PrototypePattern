using Lab3_Serious_Form.Entity;

namespace Lab3_Serious_Form.Repository.Validators
{
    // визитор, в нашем случае проверки, которые будут применяться к элементам
    public interface IVisitor
    {
        void CheckReview(Review review);
    }
}
