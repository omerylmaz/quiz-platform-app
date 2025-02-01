using Common.Application.Messaging;

namespace Subscriptions.Application.Payments.GetPaymentsByCustomerId;

public sealed record GetPaymentsByCustomerIdQuery(Guid CustomerId) : IQuery<IReadOnlyCollection<PaymentResponse>>;
