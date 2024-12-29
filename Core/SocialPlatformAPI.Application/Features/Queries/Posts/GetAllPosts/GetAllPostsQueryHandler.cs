using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Posts;
using SocialPlatformAPI.Application.Interfaces.Services;
using System.Collections.Generic;

namespace SocialPlatformAPI.Application.Features.Queries.Posts.GetAllPosts
{
    public class GetAllPostsQueryHandler(IPostService postService, IMapper mapper) : IRequestHandler<GetAllPostsQueryRequest, IList<GetAllPostsQueryResponse>>
    {
        public async Task<IList<GetAllPostsQueryResponse>> Handle(GetAllPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var posts = await postService.GetAllPostsAsync(new() { PageCount = request.PageCount, ItemCount = request.ItemCount });
            return mapper.Map<IList<GetPostDTO>, IList <GetAllPostsQueryResponse>>(posts);
        }
    }
}
