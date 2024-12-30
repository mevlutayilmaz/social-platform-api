using Microsoft.AspNetCore.Identity;

namespace SocialPlatformAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
        public ICollection<Follow> Followers { get; set; } = new HashSet<Follow>();
        public ICollection<Follow> Following { get; set; } = new HashSet<Follow>();
    }
}
