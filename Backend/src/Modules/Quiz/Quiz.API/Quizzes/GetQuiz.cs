using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Quiz.API.Database;

namespace Quiz.API.Quizzes;
public static class GetQuiz
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("quizzes/{id}", async (Guid id, QuizDbContext context, CancellationToken cancellationToken) =>
        {
            QuizResponse? quiz = await context.Quizzes.Where(q => q.Id == id)
            .Select(q => new QuizResponse(q.Id, q.QuizSetId, q.Title, q.Description, q.CreatedByAI, q.Difficulty))
            .FirstOrDefaultAsync(cancellationToken);

            return quiz is null ? Results.NotFound() : Results.Ok(quiz);
        })
        .WithTags(Constants.QuizzesTag);
    }
}
