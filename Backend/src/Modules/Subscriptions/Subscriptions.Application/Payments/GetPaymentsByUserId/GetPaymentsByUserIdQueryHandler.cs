using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Domain.Payments;

namespace Subscriptions.Application.Payments.GetPaymentsByUserId;

internal sealed class GetPaymentsByUserIdQueryHandler(
    IPaymentRepository paymentRepository) : IQueryHandler<GetPaymentsByUserIdQuery, IReadOnlyCollection<PaymentResponse>>
{
    public async Task<Result<IReadOnlyCollection<PaymentResponse>>> Handle(GetPaymentsByUserIdQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Payment> payments = await paymentRepository.GetAllByUserIdAsync(request.UserId, cancellationToken);

        IReadOnlyCollection<PaymentResponse> paymentResponses = payments.Select(p => new PaymentResponse(p.Id, p.UserId, p.Amount, p.PaymentStatus.ToString(), p.TransactionId, p.CreatedDate)).ToList();

        return Result.Success(paymentResponses);
    }
}
