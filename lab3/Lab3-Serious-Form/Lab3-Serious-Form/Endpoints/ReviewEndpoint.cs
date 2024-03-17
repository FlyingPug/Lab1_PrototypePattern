using Lab3_Serious_Form.Mappers;
using Lab3_Serious_Form.Models;
using Lab3_Serious_Form.Services;
using Microsoft.AspNetCore.Http;
namespace Lab3_Serious_Form.Endpoints
{

    // дублирует контроллер
    public static class ReviewEndpoint
    {
        private const string _baseSaleRoute = "/api/reviews";

        // метод расширения для app
        public static void MapUserEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost(_baseSaleRoute, async (CreateReviewRequest request, IReviewService service, CancellationToken cancellationToken) =>
            {
                var review = await service.CreateAsync(request, cancellationToken);
                return Results.Json(ReviewMapper.Map(review));
            })
            .AllowAnonymous()
            .WithTags(nameof(ReviewEndpoint))
            .Produces<ReviewModel>();
            //.WithOpenApi();

            endpoints.MapGet(_baseSaleRoute, async (IReviewService service, CancellationToken cancellationToken) =>
            {
                var reviews = await service.GetAllAsync(cancellationToken);
                return Results.Json(reviews.Select(ReviewMapper.Map));
            })
            .AllowAnonymous()
            .WithTags(nameof(ReviewEndpoint))
            .Produces<IEnumerable<ReviewModel>>();
        }
    }
}
