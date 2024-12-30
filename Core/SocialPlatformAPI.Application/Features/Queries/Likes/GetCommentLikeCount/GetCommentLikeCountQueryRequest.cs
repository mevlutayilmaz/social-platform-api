using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.Likes.GetCommentLikeCount
{
    public class GetCommentLikeCountQueryRequest : IRequest<GetCommentLikeCountQueryResponse>
    {
        public string CommentId { get; set; }
    }
}