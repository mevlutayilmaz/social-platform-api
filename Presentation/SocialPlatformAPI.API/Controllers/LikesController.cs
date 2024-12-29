using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformAPI.Application.Features.Commands.Likes.LikePost;
using SocialPlatformAPI.Application.Features.Queries.Likes.GetLikeCount;

namespace SocialPlatformAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLikeCount([FromQuery] GetLikeCountQueryRequest request)
        {
            GetLikeCountQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> LikePost(LikePostCommandRequest request)
        {
            LikePostCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
