using Ganss.Xss;
using Lab3_Serious_Form.Entity;
using Lab3_Serious_Form.Exceptions;
using MongoDB.Bson;
using System.Text.RegularExpressions;

namespace Lab3_Serious_Form.Repository.Validators
{
    public class BSONVisitor : IVisitor
    {
        public void CheckReview(Review review)
        {
            string pattern = @"(\$where|\{.*?\$\w+\})";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(review.Email) ||
                !regex.IsMatch(review.Name) ||
                !regex.IsMatch(review.Message) ||
                !regex.IsMatch(review.PhoneNumber)) throw new IncorrectEmail("Попытка NoSql инъекции");
        }
    }
}
