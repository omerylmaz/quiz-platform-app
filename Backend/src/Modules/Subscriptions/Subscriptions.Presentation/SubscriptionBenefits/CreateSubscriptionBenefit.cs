using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Subscriptions.Application.SubscriptionBenefits.CreateSubscriptionBenefit;

namespace Subscriptions.Presentation.SubscriptionBenefits;

internal sealed class CreateSubscriptionBenefit : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("subscription-benefits", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateSubscriptionBenefitCommand(
                request.Name,
                request.Value
                );
            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.SubscriptionBenefits);
    }

    public sealed record Request
    {
        public string Name { get; init; }
        public string Value { get; init; }
    }
}
