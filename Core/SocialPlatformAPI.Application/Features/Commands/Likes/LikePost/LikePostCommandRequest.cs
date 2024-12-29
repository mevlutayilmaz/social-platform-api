using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.Likes.LikePost
{
    public class LikePostCommandRequest : IRequest<LikePostCommandResponse>
    {
        public string PostId { get; set; }
    }
}