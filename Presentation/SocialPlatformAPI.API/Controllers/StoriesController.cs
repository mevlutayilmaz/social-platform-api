using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformAPI.Application.Features.Queries.Stories.GetStories;
using SocialPlatformAPI.Application.Interfaces.Services;

namespace SocialPlatformAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController(IMediator mediator, IStoryService storyService) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStories([FromQuery] GetStoriesQueryRequest request)
        {
            IList<GetStoriesQueryResponse> response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateStory(string imageUrl)
        {
            await storyService.CreateStoryAsync(imageUrl);
            return Ok();
        }
        
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteStory(string id)
        {
            await storyService.DeleteStoryAsync(id);
            return Ok();
        }
    }
}
