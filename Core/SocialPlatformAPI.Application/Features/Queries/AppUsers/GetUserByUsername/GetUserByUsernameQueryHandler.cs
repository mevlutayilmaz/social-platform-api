using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetUserByUsername
{
    public class GetUserByUsernameQueryHandler(IUserService userService, IMapper mapper) : IRequestHandler<GetUserByUsernameQueryRequest, GetUserByUsernameQueryResponse>
    {
        public async Task<GetUserByUsernameQueryResponse> Handle(GetUserByUsernameQueryRequest request, CancellationToken cancellationToken)
        {
            GetUserByUsernameDTO user = await userService.GetUserByUsernameAsync(request.Username);
            return mapper.Map<GetUserByUsernameDTO, GetUserByUsernameQueryResponse>(user);
        }
    }
}
