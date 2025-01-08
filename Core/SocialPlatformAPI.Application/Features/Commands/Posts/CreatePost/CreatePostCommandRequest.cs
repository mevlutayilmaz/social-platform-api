using MediatR;
using Microsoft.AspNetCore.Http;

namespace SocialPlatformAPI.Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostCommandRequest : IRequest<CreatePostCommandResponse>
    {
        public string Content { get; set; }
        public IFormFileCollection? File { get; set; }
    }
}