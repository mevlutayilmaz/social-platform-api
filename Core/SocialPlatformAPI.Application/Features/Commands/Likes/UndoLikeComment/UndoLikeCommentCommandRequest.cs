using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.Likes.UndoLikeComment
{
    public class UndoLikeCommentCommandRequest : IRequest<UndoLikeCommentCommandResponse>
    {
        public string CommentId { get; set; }
    }
}