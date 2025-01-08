using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.DTOs.Stories
{
    public class GetStoriesDTO
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public GetUserDTO User { get; set; }
    }
}
