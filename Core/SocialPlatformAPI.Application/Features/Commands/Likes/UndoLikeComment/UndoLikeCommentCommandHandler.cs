using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Likes.UndoLikeComment
{
    public class UndoLikeCommentCommandHandler(ILikeService likeService) : IRequestHandler<UndoLikeCommentCommandRequest, UndoLikeCommentCommandResponse>
    {
        public async Task<UndoLikeCommentCommandResponse> Handle(UndoLikeCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await likeService.UndoLikeCommentAsync(request.CommentId);
            return new();
        }
    }
}
