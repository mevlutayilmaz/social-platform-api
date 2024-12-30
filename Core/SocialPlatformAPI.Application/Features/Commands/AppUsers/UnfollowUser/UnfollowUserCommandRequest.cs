using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.UnfollowUser
{
    public class UnfollowUserCommandRequest : IRequest<UnfollowUserCommandResponse>
    {
        public string FollowingId { get; set; }
    }
}