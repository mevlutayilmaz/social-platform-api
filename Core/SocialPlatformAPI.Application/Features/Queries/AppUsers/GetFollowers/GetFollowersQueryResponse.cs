namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetFollowers
{
    public class GetFollowersQueryResponse
    {
        public string Username { get; set; }
        public string NameSurname { get; set; }
        public string? ProfilePicture { get; set; }
    }
}