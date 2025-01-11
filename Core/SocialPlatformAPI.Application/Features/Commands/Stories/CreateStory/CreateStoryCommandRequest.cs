using MediatR;
using Microsoft.AspNetCore.Http;

namespace SocialPlatformAPI.Application.Features.Commands.Stories.CreateStory
{
    public class CreateStoryCommandRequest : IRequest<CreateStoryCommandResponse>
    {
        public IFormFileCollection File { get; set; }
    }
}