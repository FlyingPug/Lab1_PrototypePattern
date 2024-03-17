using Lab3_Serious_Form.Entity;
using Lab3_Serious_Form.Exceptions;
using System.Text.RegularExpressions;

namespace Lab3_Serious_Form.Repository.Validators
{
    public class RegexVisitor : IVisitor
    {
        public void CheckReview(Review review)
        {
            Regex emailRegex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            Regex phoneRegex = new Regex("^(\\+?\\d{1,4}-?)?(\\d{1,3}-?){2}(\\d{2}-?){2}\\d{2}$");
            if (!emailRegex.IsMatch(review.Email)) throw new IncorrectEmail("Неверный формат мыла");
            if (!phoneRegex.IsMatch(review.PhoneNumber)) throw new IncorrectPhoneNumber("Неверный формат телефона");
            if (review.Name.Length < 1 || review.Name.Length > 20) throw new IncorrectData("Имя слишком длинное или слишком короткое");
            if (review.Message.Length < 1 || review.Name.Length > 300) throw new IncorrectData("Сообщение слишком длинное или слишком короткое");
        }
    }
}
