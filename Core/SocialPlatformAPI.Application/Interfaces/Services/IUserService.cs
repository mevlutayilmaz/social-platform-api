using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Application.Interfaces.Services
{
    public interface IUserService
    {
        public string? GetCurrentUsername { get; }
        Task<AppUser?> GetCurrentUserAsync();
        Task<GetUserByUsernameDTO> GetUserByUsernameAsync(string username);
        Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO user);
        Task UpdateUserAsync(UpdateUserDTO user);
        Task UpdateUserProfilePicAsync(string profilePic);
        Task UpdateUserCoverPicAsync(string coverPic);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task FollowUserAsync(string username);
        Task UnfollowUserAsync(string username);
        Task<IList<GetUserDTO>> GetFollowersAsync(string userId);
        Task<IList<GetUserDTO>> GetFollowingAsync(string userId);
    }
}
