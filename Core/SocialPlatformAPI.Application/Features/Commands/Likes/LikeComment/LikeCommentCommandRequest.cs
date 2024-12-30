using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.Likes.LikeComment
{
    public class LikeCommentCommandRequest : IRequest<LikeCommentCommandResponse>
    {
        public string CommentId { get; set; }
    }
}