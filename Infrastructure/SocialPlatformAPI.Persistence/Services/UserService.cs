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

        public async Task<GetUserByUsernameDTO> GetUserByUsernameAsync(string username)
        {
            AppUser? user = await userManager.Users
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .FirstOrDefaultAsync(u => u.UserName == username);

            AppUser? currentUser = await GetCurrentUserAsync();

            if (user is not null && currentUser is not null)
            {
                GetUserByUsernameDTO dto = mapper.Map<AppUser, GetUserByUsernameDTO>(user);
                dto.IsFollowed = user.Followers.Any(f => f.FollowerId == currentUser.Id);
                return dto;
            }
            throw new Exception("User not found!");
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

        public async Task FollowUserAsync(string username)
        {
            AppUser? currentUser = await GetCurrentUserAsync();
            AppUser? user = await userManager.FindByNameAsync(username);
            if (currentUser is not null && user is not null)
            {
                await followWriteRepository.AddAsync(new()
                {
                    FollowerId = currentUser.Id,
                    FollowingId = user.Id,
                    CreatedDate = DateTime.UtcNow
                });
                await followWriteRepository.SaveAsync();
            }
        }

        public async Task UnfollowUserAsync(string username)
        {
            AppUser? currentUser = await GetCurrentUserAsync();
            AppUser? user = await userManager.FindByNameAsync(username);
            if (currentUser is not null && user is not null)
            {
                Follow follow = await followReadRepository.GetAsync(
                    predicate: f => f.FollowerId == currentUser.Id && f.FollowingId == user.Id,
                    enableTracking: true);
                followWriteRepository.Remove(follow);
                await followWriteRepository.SaveAsync();
            }
        }

        public async Task<IList<GetUserDTO>> GetFollowersAsync(string username)
        {
            IList<AppUser> followers = await followReadRepository
                .GetAll(f => f.Following.UserName == username, include: x => x.Include(f => f.Following))
                .Select(f => f.Follower)
                .ToListAsync();

            return mapper.Map<ICollection<AppUser>, IList<GetUserDTO>>(followers);
        }

        public async Task<IList<GetUserDTO>> GetFollowingAsync(string username)
        {
            IList<AppUser> following = await followReadRepository
                .GetAll(f => f.Follower.UserName == username, include: x => x.Include(f => f.Follower))
                .Select(f => f.Following)
                .ToListAsync();

            return mapper.Map<IList<AppUser>, IList<GetUserDTO>>(following);
        }

        public async Task UpdateUserProfilePicAsync(string profilePic)
        {
            AppUser? user = await GetCurrentUserAsync();
            if(user is not null)
            {
                user.ProfilePicture = profilePic;
                await userManager.UpdateAsync(user);
            }
        }

        public async Task UpdateUserCoverPicAsync(string coverPic)
        {
            AppUser? user = await GetCurrentUserAsync();
            if (user is not null)
            {
                user.CoverPicture = coverPic;
                await userManager.UpdateAsync(user);
            }
        }

        public async Task UpdateUserAsync(UpdateUserDTO user)
        {
            AppUser? currentUser = await GetCurrentUserAsync();
            if (currentUser is not null)
            {
                mapper.Map(user, currentUser);
                IdentityResult result = await userManager.UpdateAsync(currentUser);
            }
        }

        public async Task<IList<GetUserDTO>> SuggestionsUserAsync()
        {
            AppUser? user = await GetCurrentUserAsync();
            if(user is not null)
            {
                var users = await userManager.Users
                    .Include(u => u.Followers)
                    .Where(u => !u.Followers.Any(f => f.FollowerId == user.Id) && u.Id != user.Id)
                    .ToListAsync();

                return mapper.Map<IList<GetUserDTO>>(users);
            }
            return null;
        }
    }
}
