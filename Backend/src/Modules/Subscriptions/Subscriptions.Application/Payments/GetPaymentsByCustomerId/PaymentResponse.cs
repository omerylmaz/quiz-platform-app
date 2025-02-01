namespace Subscriptions.Application.Payments.GetPaymentsByCustomerId;

public record PaymentResponse(Guid Id, Guid CustomerId, decimal Amount, string PaymentStatus, string TransactionId, DateTime CreatedDate);
