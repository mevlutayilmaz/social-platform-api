using SocialPlatformAPI.Application.DTOs;

namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<TokenDTO> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task<TokenDTO> RefreshTokenLoginAsync(string refreshToken);
        Task LogoutAsync();
    }
}
