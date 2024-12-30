namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowing
{
    public class GetFollowingQueryResponse
    {
        public string Username { get; set; }
        public string NameSurname { get; set; }
        public string? ProfilePicture { get; set; }
    }
}