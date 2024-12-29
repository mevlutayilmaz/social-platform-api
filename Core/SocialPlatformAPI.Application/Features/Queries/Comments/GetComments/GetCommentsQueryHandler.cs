using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Comments;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.Comments.GetComments
{
    public class GetCommentsQueryHandle(ICommentService commentService, IMapper mapper) : IRequestHandler<GetCommentsQueryRequest, IList<GetCommentsQueryResponse>>
    {
        public async Task<IList<GetCommentsQueryResponse>> Handle(GetCommentsQueryRequest request, CancellationToken cancellationToken)
        {
            IList<GetCommentDTO> comments = await commentService.GetCommentsAsync(request.PostId);
            return mapper.Map<IList<GetCommentDTO>, IList<GetCommentsQueryResponse>>(comments);
        }
    }
}
