using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostCommandRequest : IRequest<CreatePostCommandResponse>
    {
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
    }
}