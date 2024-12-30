using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.CreateUser;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.FollowUser;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.UnfollowUser;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowers;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowing;

namespace SocialPlatformAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> FollowUser(FollowUserCommandRequest request)
        {
            FollowUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("[action]")]
        public async Task<IActionResult> UnfollowUser(UnfollowUserCommandRequest request)
        {
            UnfollowUserCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetFollowing([FromQuery] GetFollowingQueryRequest request)
        {
            IList<GetFollowingQueryResponse> response = await mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetFollowers([FromQuery] GetFollowersQueryRequest request)
        {
            IList<GetFollowersQueryResponse> response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
