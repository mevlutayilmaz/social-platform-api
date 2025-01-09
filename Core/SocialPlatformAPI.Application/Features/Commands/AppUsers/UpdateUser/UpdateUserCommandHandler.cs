using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.UpdateUser
{
    public class UpdateUserCommandHandler(IUserService userService, IMapper mapper): IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await userService.UpdateUserAsync(mapper.Map<UpdateUserCommandRequest, UpdateUserDTO>(request));
            return new();
        }
    }
}
