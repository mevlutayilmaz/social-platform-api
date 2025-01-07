using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.DTOs.Posts
{
    public class GetPostDTO
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public GetUserDTO User { get; set; }
    }
}
