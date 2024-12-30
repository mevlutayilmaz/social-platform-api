using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowing
{
    public class GetFollowingQueryHandler(IUserService userService, IMapper mapper) : IRequestHandler<GetFollowingQueryRequest, IList<GetFollowingQueryResponse>>
    {
        public async Task<IList<GetFollowingQueryResponse>> Handle(GetFollowingQueryRequest request, CancellationToken cancellationToken)
        {
            IList<GetUserDTO> following = await userService.GetFollowingAsync(request.UserId);
            return mapper.Map<IList<GetUserDTO>, IList<GetFollowingQueryResponse>>(following);
        }
    }
}
