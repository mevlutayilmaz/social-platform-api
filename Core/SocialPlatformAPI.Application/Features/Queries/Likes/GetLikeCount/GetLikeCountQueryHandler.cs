using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.Likes.GetLikeCount
{
    public class GetLikeCountQueryHandler(ILikeService likeService) : IRequestHandler<GetLikeCountQueryRequest, GetLikeCountQueryResponse>
    {
        public async Task<GetLikeCountQueryResponse> Handle(GetLikeCountQueryRequest request, CancellationToken cancellationToken)
        {
            int count = await likeService.GetLikeCountAsync(request.PostId);
            return new() { Count = count };
        }
    }
}
