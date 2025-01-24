using Common.Domain;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Categories.GetCategory;
using Quiz.Presentation.ApiResults;

namespace Quiz.Presentation.Categories;

internal static class GetCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<CategoryResponse>? result = await sender.Send(new GetCategoryQuery(id), cancellationToken);

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Categories);
    }
}
