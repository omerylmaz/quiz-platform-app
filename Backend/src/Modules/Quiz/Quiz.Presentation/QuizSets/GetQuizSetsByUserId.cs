﻿using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.QuizSets.GetQuizSet;
using Quiz.Application.QuizSets.GetQuizSetsByUserId;

namespace Quiz.Presentation.QuizSets;

internal sealed class GetQuizSetsByUserId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("quiz-sets/user/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<IReadOnlyCollection<QuizSetResponse>> result = await sender.Send(new GetQuizSetsByUserIdQuery(id), cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.QuizSets);
    }
}
