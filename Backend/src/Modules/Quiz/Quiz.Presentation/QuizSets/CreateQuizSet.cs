using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.QuizSets.CreateQuizSet;
using Quiz.Domain.Abstractions;
using Quiz.Presentation.ApiResults;

namespace Quiz.Presentation.QuizSets;

internal static class CreateQuizSet
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("quiz-sets", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateQuizSetCommand(request.Title, request.Description, request.UserId, request.Categories);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Categories);
    }
    //TODDO: userid leri daha sonra authorization ile çek
    internal sealed record Request(string Title, string Description, Guid UserId, List<Guid> Categories);
}
