using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Categories.GetCategories;
using Quiz.Application.Categories.GetCategory;

namespace Quiz.Presentation.Categories;

public sealed class GetCategories : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories", async (ISender sender, CancellationToken cancellationToken) =>
        {
            Result<IReadOnlyCollection<CategoryResponse>>? result = await sender.Send(new GetCategoriesQuery(), cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Categories);
    }
}
