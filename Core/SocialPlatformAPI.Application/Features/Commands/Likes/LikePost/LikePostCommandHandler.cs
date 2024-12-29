using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Likes.LikePost
{
    public class LikePostCommandHandler(ILikeService likeService) : IRequestHandler<LikePostCommandRequest, LikePostCommandResponse>
    {
        public async Task<LikePostCommandResponse> Handle(LikePostCommandRequest request, CancellationToken cancellationToken)
        {
            await likeService.LikePostAsync(request.PostId);
            return new();
        }
    }
}
