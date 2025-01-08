using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<(TokenDTO, GetUserDTO)> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task<TokenDTO> RefreshTokenLoginAsync(string refreshToken);
        Task LogoutAsync();
    }
}
