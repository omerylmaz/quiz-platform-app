﻿using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Quizzes.CreateQuiz;
using Quiz.Domain.Quizzes;

namespace Quiz.Presentation.Quizzes;

internal sealed class CreateQuiz : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("quizzes", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateQuizCommand(
                request.QuizSetId,
                request.Title,
                request.Description,
                request.Difficulty,
                request.CreatedByAI);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Quizzes);
    }

    internal sealed class Request
    {
        public Guid QuizSetId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public QuizDifficulty Difficulty { get; set; }

        public bool CreatedByAI { get; set; }
    }
}
