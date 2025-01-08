using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.Features.Commands.Auth.Login
{
    public class LoginCommandResponse
    {
        public TokenDTO Token { get; set; }
        public GetUserDTO User { get; set; }
    }
}