using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.Likes.GetCommentLikeCount
{
    public class GetCommentLikeCountQueryHandler(ILikeService likeService) : IRequestHandler<GetCommentLikeCountQueryRequest, GetCommentLikeCountQueryResponse>
    {
        public async Task<GetCommentLikeCountQueryResponse> Handle(GetCommentLikeCountQueryRequest request, CancellationToken cancellationToken)
        {
            int count = await likeService.GetCommentLikeCountAsync(request.CommentId);
            return new() { Count = count };
        }
    }
}
