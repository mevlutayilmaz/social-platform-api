using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowers
{
    public class GetFollowersQueryHandler(IUserService userService, IMapper mapper) : IRequestHandler<GetFollowersQueryRequest, IList<GetFollowersQueryResponse>>
    {
        public async Task<IList<GetFollowersQueryResponse>> Handle(GetFollowersQueryRequest request, CancellationToken cancellationToken)
        {
            IList<GetUserDTO> followers = await userService.GetFollowersAsync(request.UserId);
            return mapper.Map<IList<GetUserDTO>, IList<GetFollowersQueryResponse>>(followers);
        }
    }
}
