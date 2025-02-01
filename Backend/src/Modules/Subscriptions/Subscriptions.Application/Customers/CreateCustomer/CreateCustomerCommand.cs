using Common.Application.Messaging;

namespace Subscriptions.Application.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(Guid CustomerId, string Email, string FirstName, string LastName)
    : ICommand;
