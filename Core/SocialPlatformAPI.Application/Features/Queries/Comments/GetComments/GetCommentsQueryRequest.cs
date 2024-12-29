using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.Comments.GetComments
{
    public class GetCommentsQueryRequest : IRequest<IList<GetCommentsQueryResponse>>
    {
        public string PostId { get; set; }
    }
}