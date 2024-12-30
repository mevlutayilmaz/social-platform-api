using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformAPI.Application.Features.Commands.Likes.LikeComment;
using SocialPlatformAPI.Application.Features.Commands.Likes.LikePost;
using SocialPlatformAPI.Application.Features.Commands.Likes.UndoLikeComment;
using SocialPlatformAPI.Application.Features.Commands.Likes.UndoLikePost;
using SocialPlatformAPI.Application.Features.Queries.Likes.GetCommentLikeCount;
using SocialPlatformAPI.Application.Features.Queries.Likes.GetLikeCount;

namespace SocialPlatformAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPostLikeCount([FromQuery] GetPostLikeCountQueryRequest request)
        {
            GetPostLikeCountQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCommentLikeCount([FromQuery] GetCommentLikeCountQueryRequest request)
        {
            GetCommentLikeCountQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> LikePost(LikePostCommandRequest request)
        {
            LikePostCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LikeComment(LikeCommentCommandRequest request)
        {
            LikeCommentCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpDelete("[action]")]
        public async Task<IActionResult> UndoLikePost(UndoLikePostCommandRequest request)
        {
            UndoLikePostCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpDelete("[action]")]
        public async Task<IActionResult> UndoLikeComment(UndoLikeCommentCommandRequest request)
        {
            UndoLikeCommentCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
