using Common.Application.EventBus;
using Common.Application.Exceptions;
using Common.Application.Messaging;
using Common.Domain;
using MediatR;
using Subscriptions.IntegrationEvents;
using Users.Application.Users.GetUser;
using Users.Domain.Users;

namespace Users.Application.Users.RegisterUser;

internal sealed class UserRegisteredDomainEventHandler(
    ISender sender,
    IEventBus eventBus)
    : IDomainEventHandler<UserRegisteredDomainEvent>
{
    public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        Result<UserResponse> result = await sender.Send(new GetUserQuery(notification.UserId), cancellationToken);

        if (result.IsFailure)
            throw new QuizAppException(nameof(GetUserQuery), result.Error);

        await eventBus.PublishAsync(
            new UserRegisteredIntegrationEvent(
                notification.Id,
                notification.OccuredOn,
                result.Value.Id,
                result.Value.Email,
                result.Value.FirstName,
                result.Value.LastName
                ),
            cancellationToken
            );
    }
}
