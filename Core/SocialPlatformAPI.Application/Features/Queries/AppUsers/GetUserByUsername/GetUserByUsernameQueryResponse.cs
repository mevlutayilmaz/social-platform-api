namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetUserByUsername
{
    public class GetUserByUsernameQueryResponse
    {
        public string Username { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePicture { get; set; }
    }
}