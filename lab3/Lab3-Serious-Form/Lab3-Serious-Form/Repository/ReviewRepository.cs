using Ganss.Xss;
using Lab3_Serious_Form.Entity;
using Lab3_Serious_Form.Exceptions;
using MongoDB.Driver;
using SharpCompress.Common;
using System.Text.RegularExpressions;

namespace Lab3_Serious_Form.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private const string _collectionName = "reviews";
        private readonly HtmlSanitizer sanitizer;
        private Regex emailRegex;
        private Regex phoneRegex;
        IMongoDatabase mongoDatabase;

        public ReviewRepository(IMongoDatabase mongoDatabase)
        {
            this.mongoDatabase = mongoDatabase;
            this.sanitizer = new HtmlSanitizer();
            emailRegex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            phoneRegex = new Regex("^(\\+?\\d{1,4}-?)?(\\d{1,3}-?){2}(\\d{2}-?){2}\\d{2}$");
        }

        public async Task<Review> CreateAsync(Review newReview, CancellationToken cancellationToken)
        {
            var options = new InsertOneOptions();

            if (!emailRegex.IsMatch(newReview.Email)) throw new IncorrectEmail("Неверный формат мыла");
            if (!phoneRegex.IsMatch(newReview.PhoneNumber)) throw new IncorrectPhoneNumber("Неверный формат телефона");


            newReview.Name = sanitizer.Sanitize(newReview.Name);
            newReview.Email = sanitizer.Sanitize(newReview.Name);
            newReview.Message = sanitizer.Sanitize(newReview.Name);
            newReview.PhoneNumber = sanitizer.Sanitize(newReview.Name);
            
            // тут уже защита от bson
            await mongoDatabase.GetCollection<Review>(_collectionName).InsertOneAsync(newReview, options, cancellationToken);
            return newReview;
        }

        public Task<List<Review>> GetAllAsync(CancellationToken cancellationToken)
        {
            return mongoDatabase.GetCollection<Review>(_collectionName)
                .Find(x => true)
                .ToListAsync();
        }
    }
}
