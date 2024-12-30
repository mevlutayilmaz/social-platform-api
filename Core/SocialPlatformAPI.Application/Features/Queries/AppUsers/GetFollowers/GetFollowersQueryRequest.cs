using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowers
{
    public class GetFollowersQueryRequest : IRequest<IList<GetFollowersQueryResponse>>
    {
        public string UserId { get; set; }
    }
}