using MediatR;

namespace SocialPlatformAPI.Application.Features.Commands.Auth.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandRequest : IRequest<RefreshTokenLoginCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}