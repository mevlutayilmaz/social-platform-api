using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.UnfollowUser
{
    public class UnfollowUserCommandHandler(IUserService userService) : IRequestHandler<UnfollowUserCommandRequest, UnfollowUserCommandResponse>
    {
        public async Task<UnfollowUserCommandResponse> Handle(UnfollowUserCommandRequest request, CancellationToken cancellationToken)
        {
            await userService.UnfollowUserAsync(request.FollowingId);
            return new();
        }
    }
}
