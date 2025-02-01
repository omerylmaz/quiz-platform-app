using Common.Application.Messaging;

namespace Subscriptions.Application.Payments.GetPaymentsByUserId;

public sealed record GetPaymentsByUserIdQuery(Guid UserId) : IQuery<IReadOnlyCollection<PaymentResponse>>;
