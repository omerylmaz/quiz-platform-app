using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Domain.Payments;

namespace Subscriptions.Application.Payments.GetPaymentsByCustomerId;

internal sealed class GetPaymentsByCustomerIdQueryHandler(
    IPaymentRepository paymentRepository) : IQueryHandler<GetPaymentsByCustomerIdQuery, IReadOnlyCollection<PaymentResponse>>
{
    public async Task<Result<IReadOnlyCollection<PaymentResponse>>> Handle(GetPaymentsByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Payment> payments = await paymentRepository.GetAllByCustomerIdAsync(request.CustomerId, cancellationToken);

        IReadOnlyCollection<PaymentResponse> paymentResponses = payments.Select(p => new PaymentResponse(p.Id, p.CustomerId, p.Amount, p.PaymentStatus.ToString(), p.TransactionId, p.CreatedDate)).ToList();

        return Result.Success(paymentResponses);
    }
}
