using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.QuizSets.CreateQuizSet;

namespace Quiz.Presentation.QuizSets;

internal sealed class CreateQuizSet : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("quiz-sets", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateQuizSetCommand(request.Title, request.Description, request.UserId, request.Categories);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.QuizSets);
    }
    //TODDO: userid leri daha sonra authorization ile çek
    internal sealed record Request(string Title, string Description, Guid UserId, List<Guid> Categories);
}
