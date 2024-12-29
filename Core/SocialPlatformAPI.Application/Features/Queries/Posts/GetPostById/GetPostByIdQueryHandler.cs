using MediatR;
using SocialPlatformAPI.Application.DTOs.Posts;
using SocialPlatformAPI.Application.Interfaces.AutoMapper;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.Posts.GetPostById
{
    public class GetPostByIdQueryHandler(IPostService postService, IMapper mapper) : IRequestHandler<GetPostByIdQueryRequest, GetPostByIdQueryResponse>
    {
        public async Task<GetPostByIdQueryResponse> Handle(GetPostByIdQueryRequest request, CancellationToken cancellationToken)
        {
            GetPostDTO post = await postService.GetPostByIdAsync(request.PostId);
            return mapper.Map<GetPostByIdQueryResponse, GetPostDTO>(post);
        }
    }
}
