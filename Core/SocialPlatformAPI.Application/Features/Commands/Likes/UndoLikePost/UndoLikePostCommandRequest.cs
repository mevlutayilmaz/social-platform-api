using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.Likes.UndoLikePost
{
    public class UndoLikePostCommandRequest : IRequest<UndoLikePostCommandResponse>
    {
        public string PostId { get; set; }
    }
}