using MediatR;
using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.Interfaces.AutoMapper;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Auth.Login
{
    public class LoginCommandHandler(IAuthService authService, IMapper mapper) : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            TokenDTO token = await authService.LoginAsync(request.UsernameOrEmail, request.Password, 60);
            return mapper.Map<LoginCommandResponse, TokenDTO>(token);
        }
    }
}
