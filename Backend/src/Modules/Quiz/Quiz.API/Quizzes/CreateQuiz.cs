using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.API.Database;

namespace Quiz.API.Quizzes;
public static class CreateQuiz
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("quizzes", async (Request request, QuizDbContext context, CancellationToken cancellationToken) =>
        {
            Quiz quiz = new()
            {
                CreatedAt = DateTime.UtcNow,
                CreatedByAI = request.CreatedByAI,
                Description = request.Description,
                Difficulty = request.Difficulty,
                QuizSetId = request.QuizSetId,
                Title = request.Title,
                Id = Guid.NewGuid(),
            };

            await context.AddAsync(quiz, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return Results.Ok(quiz.Id);
        })
            .WithTags(Constants.QuizzesTag);
    }

    internal sealed class Request
    {
        public Guid QuizSetId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Difficulty { get; set; }

        public bool CreatedByAI { get; set; }
    }
}
