using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.Features.Queries.Comments.GetComments
{
    public class GetCommentsQueryResponse
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public GetUserDTO User { get; set; }
    }
}