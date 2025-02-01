using Common.Domain;
using Subscriptions.Domain.Customers;

namespace Subscriptions.Domain.Payments;

public sealed class Payment : Entity
{
    private Payment() { }

    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public string TransactionId { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public Customer Customer { get; private set; }

    public static Payment Create(Guid customerId, decimal amount, string transactionId)
    {
        var payment = new Payment()
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            Amount = amount,
            PaymentStatus = PaymentStatus.Pending,
            TransactionId = transactionId,
            CreatedDate = DateTime.UtcNow
        };

        //Event: Payment Created Domain Event

        return payment;
    }

    public void ChangePaymentStatus(PaymentStatus paymentStatus)
    {
        PaymentStatus = paymentStatus;
    }
}
