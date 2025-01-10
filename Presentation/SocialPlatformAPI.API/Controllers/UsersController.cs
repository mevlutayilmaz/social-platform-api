using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.CreateUser;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.FollowUser;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.UnfollowUser;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.UpdateUser;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.UploadCoverPic;
using SocialPlatformAPI.Application.Features.Commands.AppUsers.UploadProfilePic;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowers;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowing;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.GetUserByUsername;
using SocialPlatformAPI.Application.Features.Queries.AppUsers.SuggestionsUser;

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

        [HttpPut("[action]")]
        public async Task<IActionResult> UploadProfilePic([FromForm] UploadProfilePicCommandRequest request)
        {
            UploadProfilePicCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UploadCoverPic([FromForm] UploadCoverPicCommandRequest request)
        {
            UploadCoverPicCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            UpdateUserCommandResponse response = await mediator.Send(request);
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
        [HttpDelete("[action]/{Username}")]
        public async Task<IActionResult> UnfollowUser([FromRoute] UnfollowUserCommandRequest request)
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
        
        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserByUsername([FromQuery] GetUserByUsernameQueryRequest request)
        {
            GetUserByUsernameQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> SuggestionsUser([FromQuery] SuggestionsUserQueryRequest request)
        {
            IList<SuggestionsUserQueryResponse> response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
