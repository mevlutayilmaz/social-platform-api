namespace SocialPlatformAPI.Application.Features.Queries.AppUsers.GetUserByUsername
{
    public class GetUserByUsernameQueryResponse
    {
        public string Username { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string? City { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePicture { get; set; }
        public string? CoverPicture { get; set; }
        public int Following { get; set; }
        public int Follower { get; set; }
        public bool IsFollowed { get; set; }
    }
}