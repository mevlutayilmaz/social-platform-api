using MediatR;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Posts.DeletePost
{
    public class DeletePostCommandHandler(IPostService postService) : IRequestHandler<DeletePostCommandRequest, DeletePostCommandResponse>
    {
        public async Task<DeletePostCommandResponse> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            await postService.DeletePostAsync(request.PostId);
            return new();
        }
    }
}
