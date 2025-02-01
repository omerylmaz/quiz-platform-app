using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Subscriptions.Application.Payments.GetPaymentsByCustomerId;

namespace Subscriptions.Presentation.Payments;

internal sealed class GetPaymentsByCustomerId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("payments/{customerId}", async (Guid customerId, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new GetPaymentsByCustomerIdQuery(customerId);
            Result<IReadOnlyCollection<PaymentResponse>> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Payments);
    }
}
