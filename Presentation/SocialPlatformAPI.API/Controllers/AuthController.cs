using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformAPI.Application.Features.Commands.Auth.Login;
using SocialPlatformAPI.Application.Features.Commands.Auth.RefreshTokenLogin;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator, IAuthService authService) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            LoginCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin(RefreshTokenLoginCommandRequest request)
        {
            RefreshTokenLoginCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return Ok();
        }
    }
}
