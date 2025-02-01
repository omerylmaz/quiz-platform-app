using Common.Domain;
using Common.Presentation.ApiResults;
using Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Subscriptions.Application.Payments.CreatePayment;

namespace Subscriptions.Presentation.Payments;

internal sealed class CreatePayment : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("payments", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreatePaymentCommand(
                request.UserId,
                request.Amount,
                request.TransactionId
            );

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Constants.Tags.Payments);
    }

    internal sealed record Request
    {
        public Guid UserId { get; init; }
        public decimal Amount { get; init; }
        public string TransactionId { get; init; }
    }
}
