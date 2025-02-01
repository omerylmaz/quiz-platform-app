using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Subscriptions.Application.CustomerSubscriptions.CreateCustomerSubscription;

namespace Subscriptions.Presentation.CustomerSubscriptions;

internal sealed class CreateCustomerSubscription : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("customer-subscriptions", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateCustomerSubscriptionCommand(
                request.CustomerId,
                request.SubscriptionId,
                request.SubscriptionDays
            );

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.CustomerSubscriptions);
    }

    internal sealed record Request
    {
        public Guid CustomerId { get; init; }
        public Guid SubscriptionId { get; init; }
        public int SubscriptionDays { get; init; }
    }
}
