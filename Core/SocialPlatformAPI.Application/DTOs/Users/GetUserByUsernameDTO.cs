namespace SocialPlatformAPI.Application.DTOs.Users
{
    public class GetUserByUsernameDTO
    {
        public string Username { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
