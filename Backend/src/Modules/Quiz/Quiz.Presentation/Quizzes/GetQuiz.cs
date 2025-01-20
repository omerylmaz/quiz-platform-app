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

            //QuizResponse? quiz = await context.Quizzes.Where(q => q.Id == id)
            //.Select(q => new QuizResponse(q.Id, q.QuizSetId, q.Title, q.Description, q.CreatedByAI, q.Difficulty))
            //.FirstOrDefaultAsync(cancellationToken);

            return quizResponse is null ? Results.NotFound() : Results.Ok(quizResponse);
        })
        .WithTags(Constants.QuizzesTag);
    }
}
