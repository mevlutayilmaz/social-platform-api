using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        TokenDTO CreateAccessToken(int second, AppUser user);
        string CreateRefreshToken();
    }
}
