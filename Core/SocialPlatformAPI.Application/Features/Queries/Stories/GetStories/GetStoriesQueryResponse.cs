using SocialPlatformAPI.Application.DTOs.Users;

namespace SocialPlatformAPI.Application.Features.Queries.Stories.GetStories
{
    public class GetStoriesQueryResponse
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public GetUserDTO User { get; set; }
    }
}