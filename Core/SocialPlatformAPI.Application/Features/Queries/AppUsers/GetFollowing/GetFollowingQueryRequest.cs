using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowing
{
    public class GetFollowingQueryRequest : IRequest<IList<GetFollowingQueryResponse>>
    {
        public string Username { get; set; }
    }
}