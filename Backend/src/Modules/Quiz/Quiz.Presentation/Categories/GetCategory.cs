using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Categories.GetCategory;
using Quiz.Domain.Abstractions;

namespace Quiz.Presentation.Categories;

internal static class GetCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<CategoryResponse>? categoryResponse = await sender.Send(new GetCategoryQuery(id), cancellationToken);

            return categoryResponse is null ? Results.NotFound() : Results.Ok(categoryResponse);
        })
        .WithTags(Constants.Tags.Categories);
    }
}
