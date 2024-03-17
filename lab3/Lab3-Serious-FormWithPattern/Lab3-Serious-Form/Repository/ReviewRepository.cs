using Ganss.Xss;
using Lab3_Serious_Form.Entity;
using Lab3_Serious_Form.Exceptions;
using Lab3_Serious_Form.Repository.Validators;
using MongoDB.Driver;
using SharpCompress.Common;
using System.Text.RegularExpressions;

namespace Lab3_Serious_Form.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private const string _collectionName = "reviews";
        private readonly IMongoDatabase mongoDatabase;
        private readonly BSONVisitor _BSONVisitor;
        private readonly RegexVisitor _RegexVisitor;
        private readonly XSSVisitor _XSSVisitor;

        public ReviewRepository(IMongoDatabase mongoDatabase)
        {
            this.mongoDatabase = mongoDatabase;
            _BSONVisitor = new BSONVisitor();
            _RegexVisitor = new RegexVisitor();
            _XSSVisitor = new XSSVisitor();
        }

        public async Task<Review> CreateAsync(Review newReview, CancellationToken cancellationToken)
        {
            var options = new InsertOneOptions();

            newReview.Accept(_RegexVisitor);
            newReview.Accept(_XSSVisitor);
            newReview.Accept(_BSONVisitor);

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
