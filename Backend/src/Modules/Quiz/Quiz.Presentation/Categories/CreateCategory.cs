﻿using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Quiz.Application.Categories.CreateCategory;

namespace Quiz.Presentation.Categories;

internal sealed class CreateCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<Guid> result = await sender.Send(new CreateCategoryCommand(request.Name), cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Categories);
    }

    internal sealed record Request(string Name);
}
