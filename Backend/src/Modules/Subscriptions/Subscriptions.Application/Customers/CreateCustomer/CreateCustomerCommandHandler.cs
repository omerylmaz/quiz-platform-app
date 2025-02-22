﻿using Common.Application.Messaging;
using Common.Domain;
using Subscriptions.Application.Abstractions.Data;
using Subscriptions.Domain.Customers;

namespace Subscriptions.Application.Customers.CreateCustomer;

internal sealed class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCustomerCommand>
{
    public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(request.CustomerId, request.Email, request.FirstName, request.LastName);

        customerRepository.Add(customer);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
