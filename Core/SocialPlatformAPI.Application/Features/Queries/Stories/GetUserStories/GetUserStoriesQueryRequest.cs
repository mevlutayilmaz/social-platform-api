using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.Stories.GetUserStories
{
    public class GetUserStoriesQueryRequest : IRequest<IList<GetUserStoriesQueryResponse>>
    {
        public string Username { get; set; }
    }
}