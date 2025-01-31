using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Subscriptions.Application.Subscriptions.UpdateSubscription;

namespace Subscriptions.Presentation.Subscriptions;

internal sealed class UpdateSubscription : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("subscriptions/{id}", async (Guid id, Request request, ISender sender) =>
        {
            Result result = await sender.Send(new UpdateSubscriptionCommand(
                id,
                request.Name,
                request.Price,
                request.SubscriptionBenefitIds));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Subscriptions);
    }

    internal sealed record Request
    {
        public string Name { get; init; }

        public decimal Price { get; init; }

        public List<Guid> SubscriptionBenefitIds { get; init; } = [];
    }
}
