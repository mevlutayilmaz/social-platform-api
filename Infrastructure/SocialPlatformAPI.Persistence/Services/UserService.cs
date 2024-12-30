using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Repositories;
using SocialPlatformAPI.Domain.Entities;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Persistence.Services
{
    public class UserService(
        UserManager<AppUser> userManager, 
        IHttpContextAccessor httpContextAccessor,
        IWriteRepository<Follow> followWriteRepository,
        IReadRepository<Follow> followReadRepository,
        IMapper mapper) : IUserService
    {
        public string? GetCurrentUsername => httpContextAccessor?.HttpContext?.User?.Identity?.Name;

        public async Task<AppUser?> GetCurrentUserAsync()
        {
            if(!string.IsNullOrEmpty(GetCurrentUsername))
                return await userManager.FindByNameAsync(GetCurrentUsername);
            return null;
        }

        public async Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO user)
        {
            IdentityResult result = await userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = user.NameSurname,
                UserName = user.UserName,
                Email = user.Email
            }, user.Password);

            CreateUserResponseDTO response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "User created successfully.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDate);
                await userManager.UpdateAsync(user);
            }
            else
                throw new Exception("User not found!");
        }

        public async Task FollowUserAsync(string followingId)
        {
            AppUser? user = await GetCurrentUserAsync();
            if (user is not null)
            {
                await followWriteRepository.AddAsync(new()
                {
                    FollowerId = user.Id,
                    FollowingId = followingId,
                    CreatedDate = DateTime.UtcNow
                });
                await followWriteRepository.SaveAsync();
            }
        }

        public async Task UnfollowUserAsync(string followingId)
        {
            AppUser? user = await GetCurrentUserAsync();
            if(user is not null)
            {
                Follow follow = await followReadRepository.GetAsync(
                    predicate: f => f.FollowerId == user.Id && f.FollowingId == followingId,
                    enableTracking: true);
                followWriteRepository.Remove(follow);
                await followWriteRepository.SaveAsync();
            }
        }

        public async Task<IList<GetUserDTO>> GetFollowersAsync(string userId)
        {
            IList<AppUser> followers = followReadRepository
                .GetAll(f => f.FollowingId == userId)
                .Select(f => f.Follower)
                .ToList();

            return mapper.Map<ICollection<AppUser>, IList<GetUserDTO>>(followers);
        }

        public async Task<IList<GetUserDTO>> GetFollowingAsync(string userId)
        {
            IList<AppUser> following = followReadRepository
                .GetAll(f => f.FollowerId == userId)
                .Select(f => f.Following)
                .ToList();

            return mapper.Map<IList<AppUser>, IList<GetUserDTO>>(following);
        }
    }
}
