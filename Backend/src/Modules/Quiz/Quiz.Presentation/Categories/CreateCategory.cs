using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Categories.CreateCategory;
using Quiz.Domain.Abstractions;

namespace Quiz.Presentation.Categories;

internal static class CreateCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateCategoryCommand(
                request.Name);

            Result<Guid> categoryId = await sender.Send(command, cancellationToken);

            return Results.Ok(categoryId);
        })
        .WithTags(Constants.Tags.Categories);
    }

    internal sealed record Request(string Name);
}
