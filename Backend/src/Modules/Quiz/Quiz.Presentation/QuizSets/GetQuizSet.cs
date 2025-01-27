using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.QuizSets.GetQuizSet;

namespace Quiz.Presentation.QuizSets;

internal sealed class GetQuizSet : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("quiz-sets/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<QuizSetResponse> result = await sender.Send(new GetQuizSetQuery(id), cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.QuizSets);
    }
}
