using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.DTOs.Comments
{
    public class GetCommentDTO
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public GetUserDTO User { get; set; }
    }
}
