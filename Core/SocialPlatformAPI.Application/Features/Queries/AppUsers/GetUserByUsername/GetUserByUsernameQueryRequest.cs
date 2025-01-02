using MediatR;

namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetUserByUsername
{
    public class GetUserByUsernameQueryRequest : IRequest<GetUserByUsernameQueryResponse>
    {
        public string Username { get; set; }
    }
}