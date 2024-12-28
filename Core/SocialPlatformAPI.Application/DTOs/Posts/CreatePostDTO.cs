namespace SocialPlatformAPI.Application.DTOs.Posts
{
    public class CreatePostDTO
    {
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public string UserId { get; set; }
    }
}
