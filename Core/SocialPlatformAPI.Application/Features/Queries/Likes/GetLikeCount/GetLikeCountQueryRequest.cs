using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.Likes.GetLikeCount
{
    public class GetLikeCountQueryRequest : IRequest<GetLikeCountQueryResponse>
    {
        public string PostId { get; set; }
    }
}