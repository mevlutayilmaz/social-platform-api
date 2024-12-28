using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.Posts.GetAllPosts
{
    public class GetAllPostsQueryRequest : IRequest<IList<GetAllPostsQueryResponse>>
    {
        public int PageCount { get; set; } = 1;
        public int ItemCount { get; set; } = 5;
    }
}