using MediatR;
using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.Interfaces.AutoMapper;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Auth.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler(IAuthService authService, IMapper mapper) : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            TokenDTO token = await authService.RefreshTokenLoginAsync(request.RefreshToken);
            return mapper.Map<RefreshTokenLoginCommandResponse, TokenDTO>(token);
        }
    }
}
