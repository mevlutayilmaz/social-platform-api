using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.FollowUser
{
    public class FollowUserCommandRequest : IRequest<FollowUserCommandResponse>
    {
        public string FollowingId { get; set; }
    }
}