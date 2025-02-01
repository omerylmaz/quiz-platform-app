using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Application.Abstractions.Data;
using Subscriptions.Domain.Customers;
using Subscriptions.Domain.Payments;

namespace Subscriptions.Application.Payments.CreatePayment;

internal sealed class CreatePaymentCommandHandler(
    IPaymentRepository paymentRepository,
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreatePaymentCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetAsync(request.CustomerId, cancellationToken);

        if (customer is null)
            return Result.Failure<Guid>(CustomerErrors.NotFound(request.CustomerId));

        var payment = Payment.Create(request.CustomerId, request.Amount, request.TransactionId);

        paymentRepository.Add(payment);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return payment.Id;
    }
}
