using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.FollowUser
{
    public class FollowUserCommandHandler(IUserService userService) : IRequestHandler<FollowUserCommandRequest, FollowUserCommandResponse>
    {
        public async Task<FollowUserCommandResponse> Handle(FollowUserCommandRequest request, CancellationToken cancellationToken)
        {
            await userService.FollowUserAsync(request.Username);
            return new();
        }
    }
}
