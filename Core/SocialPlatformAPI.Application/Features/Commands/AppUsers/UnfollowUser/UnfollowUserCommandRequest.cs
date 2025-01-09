using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.UnfollowUser
{
    public class UnfollowUserCommandRequest : IRequest<UnfollowUserCommandResponse>
    {
        public string Username { get; set; }
    }
}