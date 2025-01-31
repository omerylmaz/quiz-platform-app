using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Subscriptions.Application.Subscriptions.GetSubscriptions;

namespace Subscriptions.Presentation.Subscriptions;

internal sealed class GetSubscriptions : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("subscriptions", async (ISender sender, CancellationToken cancellationToken) =>
        {
            Result<IReadOnlyCollection<SubscriptionResponse>>? result = await sender.Send(new GetSubscriptionsQuery(), cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Subscriptions);
    }
}
