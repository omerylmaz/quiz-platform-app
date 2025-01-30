using Common.Domain;

namespace Subscriptions.Domain.Payments;

public sealed class Payment : Entity
{
    private Payment() { }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public string TransactionId { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public static Payment Create(Guid userId, decimal amount, string transactionId)
    {
        var payment = new Payment()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Amount = amount,
            PaymentStatus = PaymentStatus.Pending,
            TransactionId = transactionId,
            CreatedDate = DateTime.Now
        };

        //Event: Payment Created Domain Event

        return payment;
    }

    public void ChangePaymentStatus(PaymentStatus paymentStatus)
    {
        PaymentStatus = paymentStatus;
    }
}
