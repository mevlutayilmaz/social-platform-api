using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.Likes.GetLikeCount
{
    public class GetPostLikeCountQueryRequest : IRequest<GetPostLikeCountQueryResponse>
    {
        public string PostId { get; set; }
    }
}