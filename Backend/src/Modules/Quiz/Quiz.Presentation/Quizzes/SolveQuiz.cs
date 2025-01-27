using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Quizzes.SolveQuiz;

namespace Quiz.Presentation.Quizzes;

internal sealed class SolveQuiz : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("quizzes/{quizId}/solve", async (Guid quizId, Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new SolveQuizCommand(
                quizId,
                request.Questions.Select(q => new SolveQuizQuestion(q.QuestionId, q.ChoiceId)).ToList()
            );

            Result<SolveQuizResponse> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
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
