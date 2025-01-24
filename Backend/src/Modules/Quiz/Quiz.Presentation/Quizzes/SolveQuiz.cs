using Common.Domain;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Quizzes.SolveQuiz;
using Quiz.Presentation.ApiResults;

namespace Quiz.Presentation.Quizzes;

internal static class SolveQuiz
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("quizzes/{quizId}/solve", async (Guid quizId, Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new SolveQuizCommand(
                quizId,
                request.Questions.Select(q => new SolveQuizQuestion(q.QuestionId, q.ChoiceId)).ToList()
            );

            Result<SolveQuizResponse> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Quizzes);
    }

    internal sealed class Request
    {
        public List<QuestionAnswer> Questions { get; set; } = [];

        internal sealed class QuestionAnswer
        {
            public Guid QuestionId { get; set; }

            public Guid ChoiceId { get; set; }
        }
    }
}
