using MediatR;
using SocialPlatformAPI.Application.DTOs.Posts;
using SocialPlatformAPI.Application.Interfaces.AutoMapper;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.Posts.GetAllPosts
{
    public class GetAllPostsQueryHandler(IPostService postService, IMapper mapper) : IRequestHandler<GetAllPostsQueryRequest, IList<GetAllPostsQueryResponse>>
    {
        public async Task<IList<GetAllPostsQueryResponse>> Handle(GetAllPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var posts = await postService.GetAllPostsAsync(new() { PageCount = request.PageCount, ItemCount = request.ItemCount });
            return mapper.Map<GetAllPostsQueryResponse, GetPostDTO>(posts);
        }
    }
}
