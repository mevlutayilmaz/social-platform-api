using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformAPI.Application.Features.Commands.Posts.CreatePost;
using SocialPlatformAPI.Application.Features.Commands.Posts.DeletePost;
using SocialPlatformAPI.Application.Features.Queries.Posts.GetAllPosts;
using SocialPlatformAPI.Application.Features.Queries.Posts.GetPostById;

namespace SocialPlatformAPI.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPosts([FromQuery] GetAllPostsQueryRequest request)
        {
            IList<GetAllPostsQueryResponse> response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{PostId}")]
        public async Task<IActionResult> GetPostById([FromRoute] GetPostByIdQueryRequest request)
        {
            GetPostByIdQueryResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePost(CreatePostCommandRequest request)
        {
            CreatePostCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpDelete("[action]/{PostId}")]
        public async Task<IActionResult> DeletePost([FromRoute] DeletePostCommandRequest request)
        {
            DeletePostCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
