using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Categories.UpdateCategory;

namespace Quiz.Presentation.Categories;

internal sealed class UpdateCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id}", async (Guid id, Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new UpdateCategoryCommand(id, request.Name);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(() => Results.Ok(), ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Categories);
    }

    internal sealed class Request
    {
        public string Name { get; set; } = string.Empty;
    }
}
