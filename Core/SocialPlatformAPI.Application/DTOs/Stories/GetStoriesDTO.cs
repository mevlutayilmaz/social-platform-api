using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.DTOs.Stories
{
    public class GetStoriesDTO
    {
        public GetUserDTO User { get; set; }
        public IList<StoryDTO> Stories { get; set; }
    }
}
