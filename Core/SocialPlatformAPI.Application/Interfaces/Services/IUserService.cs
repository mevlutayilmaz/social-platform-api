using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface IUserService
    {
        public string? GetCurrentUsername { get; }
        public AppUser? GetCurrentUser { get; }
        Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO user);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
