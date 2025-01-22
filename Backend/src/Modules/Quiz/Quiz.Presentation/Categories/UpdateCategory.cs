using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Categories.UpdateCategory;
using Quiz.Domain.Abstractions;
using Quiz.Presentation.ApiResults;

namespace Quiz.Presentation.Categories;

internal static class UpdateCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id}", async (Guid id, Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new UpdateCategoryCommand(id, request.Name);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(() => Results.Ok(), ApiResults.ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Categories);
    }

    internal sealed class Request
    {
        public string Name { get; set; } = string.Empty;
    }
}
