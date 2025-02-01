using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Subscriptions.Application.Payments.GetPaymentsByUserId;

namespace Subscriptions.Presentation.Payments;

internal sealed class GetPaymentsByUserId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("payments/{userId}", async (Guid userId, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new GetPaymentsByUserIdQuery(userId);
            Result<IReadOnlyCollection<PaymentResponse>> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Payments);
    }
}
