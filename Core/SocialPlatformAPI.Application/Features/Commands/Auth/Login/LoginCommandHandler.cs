using AutoMapper;
using MediatR;
using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.Application.Features.Commands.Auth.Login
{
    public class LoginCommandHandler(IAuthService authService) : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            (TokenDTO token, GetUserDTO user) = await authService.LoginAsync(request.UsernameOrEmail, request.Password, 60000);
            return new() { Token = token, User = user };
        }
    }
}
