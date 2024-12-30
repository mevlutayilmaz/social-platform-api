using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Likes.LikeComment
{
    public class LikeCommentCommand(ILikeService likeService) : IRequestHandler<LikeCommentCommandRequest, LikeCommentCommandResponse>
    {
        public async Task<LikeCommentCommandResponse> Handle(LikeCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await likeService.LikeCommentAsync(request.CommentId);
            return new();
        }
    }
}
