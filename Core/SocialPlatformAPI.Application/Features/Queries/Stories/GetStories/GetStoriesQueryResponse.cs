using SocialPlatformAPI.Application.DTOs.Stories;
using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.Features.Queries.Stories.GetStories
{
    public class GetStoriesQueryResponse
    {
        public GetUserDTO User { get; set; }
        public IList<StoryDTO> Stories { get; set; }
    }
}