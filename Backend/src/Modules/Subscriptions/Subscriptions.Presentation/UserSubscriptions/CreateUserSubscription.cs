using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Subscriptions.Application.UserSubscriptions.CreateUserSubscription;

namespace Subscriptions.Presentation.UserSubscriptions;

internal sealed class CreateUserSubscription : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("user-subscriptions", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateUserSubscriptionCommand(
                request.UserId,
                request.SubscriptionId,
                request.SubscriptionDays
            );

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.UserSubscriptions);
    }

    internal sealed record Request
    {
        public Guid UserId { get; init; }
        public Guid SubscriptionId { get; init; }
        public int SubscriptionDays { get; init; }
    }
}
