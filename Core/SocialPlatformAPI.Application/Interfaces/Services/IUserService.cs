using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface IUserService
    {
        public string? GetCurrentUsername { get; }
        Task<AppUser?> GetCurrentUserAsync();
        Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO user);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task FollowUserAsync(string followingId);
        Task UnfollowUserAsync(string followingId);
        Task<IList<GetUserDTO>> GetFollowersAsync(string userId);
        Task<IList<GetUserDTO>> GetFollowingAsync(string userId);
    }
}
