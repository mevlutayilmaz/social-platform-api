using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Comments.DeleteComment
{
    public class DeleteCommentCommandHandler(ICommentService commentService) : IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
    {
        public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await commentService.DeleteCommentAsync(request.Id);
            return new();
        }
    }
}
