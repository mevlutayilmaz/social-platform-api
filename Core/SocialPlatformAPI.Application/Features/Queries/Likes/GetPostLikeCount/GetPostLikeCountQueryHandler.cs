using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.Likes.GetLikeCount
{
    public class GetPostLikeCountQueryHandler(ILikeService likeService) : IRequestHandler<GetPostLikeCountQueryRequest, GetPostLikeCountQueryResponse>
    {
        public async Task<GetPostLikeCountQueryResponse> Handle(GetPostLikeCountQueryRequest request, CancellationToken cancellationToken)
        {
            int count = await likeService.GetPostLikeCountAsync(request.PostId);
            return new() { Count = count };
        }
    }
}
