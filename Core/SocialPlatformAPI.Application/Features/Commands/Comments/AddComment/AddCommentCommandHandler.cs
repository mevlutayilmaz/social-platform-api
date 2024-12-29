using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Comments.AddComment
{
    public class AddCommentCommandHandler(ICommentService commentService) : IRequestHandler<AddCommentCommandRequest, AddCommentCommandResponse>
    {
        public async Task<AddCommentCommandResponse> Handle(AddCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await commentService.AddCommentAsync(request.PostId, request.Content);
            return new();
        }
    }
}
