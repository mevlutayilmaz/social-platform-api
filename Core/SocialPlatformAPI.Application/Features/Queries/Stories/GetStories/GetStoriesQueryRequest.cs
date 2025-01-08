using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.Stories.GetStories
{
    public class GetStoriesQueryRequest : IRequest<IList<GetStoriesQueryResponse>>
    {
    }
}