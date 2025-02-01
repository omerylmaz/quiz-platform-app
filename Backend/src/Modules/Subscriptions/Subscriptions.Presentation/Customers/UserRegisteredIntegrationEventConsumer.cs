using Common.Application.Exceptions;
using Common.Domain;
using MassTransit;
using MediatR;
using Subscriptions.Application.Customers.CreateCustomer;
using Subscriptions.IntegrationEvents;

namespace Subscriptions.Presentation.Customers;

public sealed class UserRegisteredIntegrationEventConsumer(ISender sender) : IConsumer<UserRegisteredIntegrationEvent>
{
    public async Task Consume(ConsumeContext<UserRegisteredIntegrationEvent> context)
    {
        Result result = await sender.Send(new CreateCustomerCommand(
            context.Message.UserId,
            context.Message.Email,
            context.Message.FirstName,
            context.Message.LastName));

        if (result.IsFailure)
            throw new QuizAppException(nameof(CreateCustomerCommand), result.Error);
    }
}
