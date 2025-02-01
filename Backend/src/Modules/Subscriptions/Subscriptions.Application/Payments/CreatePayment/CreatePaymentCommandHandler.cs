using Common.Application.Data;
using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Domain.Payments;

namespace Subscriptions.Application.Payments.CreatePayment;

internal sealed class CreatePaymentCommandHandler(
    IPaymentRepository paymentRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreatePaymentCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        // user id check

        var payment = Payment.Create(request.UserId, request.Amount, request.TransactionId);

        paymentRepository.Add(payment);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return payment.Id;
    }
}
