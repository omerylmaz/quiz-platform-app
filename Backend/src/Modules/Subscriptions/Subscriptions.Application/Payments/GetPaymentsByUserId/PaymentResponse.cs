namespace Subscriptions.Application.Payments.GetPaymentsByUserId;

public record PaymentResponse(Guid Id, Guid UserId, decimal Amount, string PaymentStatus, string TransactionId, DateTime CreatedDate);
