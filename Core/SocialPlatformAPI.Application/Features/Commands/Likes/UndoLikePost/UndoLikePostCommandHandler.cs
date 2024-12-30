using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Likes.UndoLikePost
{
    public class UndoLikePostCommandHandler(ILikeService likeService) : IRequestHandler<UndoLikePostCommandRequest, UndoLikePostCommandResponse>
    {
        public async Task<UndoLikePostCommandResponse> Handle(UndoLikePostCommandRequest request, CancellationToken cancellationToken)
        {
            await likeService.UndoLikePostAsync(request.PostId);
            return new();
        }
    }
}
