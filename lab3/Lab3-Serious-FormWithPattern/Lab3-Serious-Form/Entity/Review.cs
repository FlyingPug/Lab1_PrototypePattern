using Lab3_Serious_Form.Repository;

namespace Lab3_Serious_Form.Entity
{
    public class Review : PersistableEntity, ICheckable
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public void Accept(IVisitor visitor)
        {
            visitor.CheckReview(this);
        }
    }
}