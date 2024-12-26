using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.Interfaces.Services;
using SocialPlatformAPI.Application.Interfaces.Tokens;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Persistence.Services
{
    public class AuthService(SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager,
        ITokenService tokenService,
        IUserService userService) : IAuthService
    {
        public async Task<TokenDTO> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            AppUser user = await userManager.FindByEmailAsync(usernameOrEmail);
            if (user is null)
                user = await userManager.FindByNameAsync(usernameOrEmail);
            if (user is null)
                throw new Exception("User not found!");

            SignInResult result = await signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                TokenDTO token = tokenService.CreateAccessToken(accessTokenLifeTime, user);
                await userService.UpdateRefreshToken(token.RefreshToken,user, token.Expiration, 24);

                return token;
            }
            throw new Exception("Authentication error!");
        }

        public async Task<TokenDTO> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if(user is not null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDTO token = tokenService.CreateAccessToken(3600, user);
                await userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 24);

                return token;
            }
            throw new Exception("User not found!");
        }
    }
}
