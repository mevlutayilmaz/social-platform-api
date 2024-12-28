using MediatR;
using SocialPlatformAPI.Application.DTOs.Posts;
using SocialPlatformAPI.Application.Interfaces.AutoMapper;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostCommandHandler(IPostService postService, IMapper mapper) : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            await postService.CreatePostAsync(mapper.Map<CreatePostDTO, CreatePostCommandRequest>(request));
            return new();
        }
    }
}
