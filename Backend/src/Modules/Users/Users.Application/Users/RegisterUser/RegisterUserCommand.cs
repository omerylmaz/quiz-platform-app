using Common.Application.Messaging;

namespace Users.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(string FirstName, string LastName, string Email, string Password)
    : ICommand<Guid>;
