using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformAPI.Application.Features.Commands.Comments.AddComment;
using SocialPlatformAPI.Application.Features.Commands.Comments.DeleteComment;
using SocialPlatformAPI.Application.Features.Queries.Comments.GetComments;

namespace SocialPlatformAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetComments([FromQuery] GetCommentsQueryRequest request)
        {
            IList<GetCommentsQueryResponse> response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddComment(AddCommentCommandRequest request)
        {
            AddCommentCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] DeleteCommentCommandRequest request)
        {
            DeleteCommentCommandResponse response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
