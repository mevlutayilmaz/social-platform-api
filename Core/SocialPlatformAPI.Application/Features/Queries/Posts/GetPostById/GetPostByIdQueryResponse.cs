using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.Features.Queries.Posts.GetPostById
{
    public class GetPostByIdQueryResponse
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public GetUserDTO User { get; set; }
    }
}