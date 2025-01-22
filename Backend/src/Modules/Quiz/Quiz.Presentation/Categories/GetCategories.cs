using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Categories.GetCategories;
using Quiz.Application.Categories.GetCategory;
using Quiz.Domain.Abstractions;
using Quiz.Presentation.ApiResults;

namespace Quiz.Presentation.Categories;

public static class GetCategories
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories", async (ISender sender, CancellationToken cancellationToken) =>
        {
            Result<IReadOnlyCollection<CategoryResponse>>? result = await sender.Send(new GetCategoriesQuery(), cancellationToken);

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Categories);
    }
}
