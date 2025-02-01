using Common.Application.Messaging;

namespace Subscriptions.Application.Payments.CreatePayment;

public sealed record CreatePaymentCommand(Guid UserId, decimal Amount, string TransactionId) : ICommand<Guid>;
