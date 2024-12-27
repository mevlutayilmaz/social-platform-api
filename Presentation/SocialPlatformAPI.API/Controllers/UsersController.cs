using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.CreateUser;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator, IUserService userService) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
