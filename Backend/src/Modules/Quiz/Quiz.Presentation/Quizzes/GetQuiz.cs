using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Quizzes.GetQuiz;

namespace Quiz.Presentation.Quizzes;

internal static class GetQuiz
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("quizzes/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            QuizResponse quizResponse = await sender.Send(new GetQuizQuery(id), cancellationToken);

            return quizResponse is null ? Results.NotFound() : Results.Ok(quizResponse);
        })
        .WithTags(Constants.Tags.Quizzes);
    }
}
