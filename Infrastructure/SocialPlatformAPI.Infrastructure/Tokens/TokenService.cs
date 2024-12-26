using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialPlatformAPI.Application.DTOs;
using SocialPlatformAPI.Application.Interfaces.Tokens;
using SocialPlatformAPI.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SocialPlatformAPI.Infrastructure.Tokens
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        public TokenDTO CreateAccessToken(int second, AppUser user)
        {
            TokenDTO token = new();
            token.Expiration = DateTime.UtcNow.AddSeconds(second);

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            JwtSecurityToken securityToken = new(
                audience: configuration["Token:Audience"],
                issuer: configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: new(securityKey, SecurityAlgorithms.HmacSha256),
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) });

            JwtSecurityTokenHandler securityTokenHandler = new();
            token.AccessToken = securityTokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
