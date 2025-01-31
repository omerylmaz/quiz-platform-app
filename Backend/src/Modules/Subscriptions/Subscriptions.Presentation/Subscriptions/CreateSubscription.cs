using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Subscriptions.Application.Subscriptions.CreateSubscription;

namespace Subscriptions.Presentation.Subscriptions;

internal sealed class CreateSubscription : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("subscriptions", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateSubscriptionCommand(
                request.Name,
                request.Price
                //request.SubscriptionBenefitIds
                );

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Subscriptions);
    }

    internal sealed record Request
    {
        public string Name { get; init; }

        public decimal Price { get; init; }
    }
}
