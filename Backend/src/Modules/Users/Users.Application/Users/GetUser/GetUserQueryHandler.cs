using Common.Application.Messaging;
using Common.Domain;
using Users.Domain.Users;

namespace Users.Application.Users.GetUser;

internal sealed class GetUserQueryHandler(IUserRepository userRepository)
    : IQueryHandler<GetUserQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetAsync(request.UserId, cancellationToken);

        if (user is null)
            return Result.Failure<UserResponse>(UserErrors.NotFound(request.UserId));

        var userResponse = new UserResponse(user.Id, user.Email, user.FirstName, user.LastName);

        return userResponse;
    }
}
