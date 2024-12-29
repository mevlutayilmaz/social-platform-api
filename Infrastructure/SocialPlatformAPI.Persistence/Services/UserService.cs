using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocialPlatformAPI.Application.DTOs.Users;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Persistence.Services
{
    public class UserService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor) : IUserService
    {
        public string? GetCurrentUsername => httpContextAccessor?.HttpContext?.User?.Identity?.Name;

        async Task<AppUser?> IUserService.GetCurrentUser()
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
    }
}
