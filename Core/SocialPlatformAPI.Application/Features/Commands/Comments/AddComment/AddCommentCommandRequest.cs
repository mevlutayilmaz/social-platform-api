using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.Comments.AddComment
{
    public class AddCommentCommandRequest : IRequest<AddCommentCommandResponse>
    {
        public string PostId { get; set; }
        public string Content { get; set; }
    }
}