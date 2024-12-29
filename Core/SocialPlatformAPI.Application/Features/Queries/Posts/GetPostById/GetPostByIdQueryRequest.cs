using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.Posts.GetPostById
{
    public class GetPostByIdQueryRequest : IRequest<GetPostByIdQueryResponse>
    {
        public string PostId { get; set; }
    }
}