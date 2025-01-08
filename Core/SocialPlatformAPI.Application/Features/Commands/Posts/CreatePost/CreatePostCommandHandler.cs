using MediatR;
using SocialPlatformAPI.Application.DTOs.Posts;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Interfaces.Storage;

namespace SocialPlatformAPI.Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostCommandHandler(IPostService postService, IStorageService storageService) : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            CreatePostDTO post = new() { Content = request.Content };
            if (request.File is not null && request.File.Any())
            {
                var files = await storageService.UploadAsync("post-images", request.File);
                post.MediaUrl = files.Select(f => $"https://localhost:7245/{f.pathOrContainerName}/{f.fileName}").First();
            }
            await postService.CreatePostAsync(post);
            return new();
        }
    }
}
