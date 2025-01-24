using Common.Domain;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.QuizSets.GetQuizSet;
using Quiz.Presentation.ApiResults;

namespace Quiz.Presentation.QuizSets;

internal static class GetQuizSet
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("quiz-sets/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<QuizSetResponse> result = await sender.Send(new GetQuizSetQuery(id), cancellationToken);

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Constants.Tags.QuizSets);
    }
}
