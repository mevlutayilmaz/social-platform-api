using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.Posts.DeletePost
{
    public class DeletePostCommandRequest : IRequest<DeletePostCommandResponse>
    {
        public string PostId { get; set; }
    }
}