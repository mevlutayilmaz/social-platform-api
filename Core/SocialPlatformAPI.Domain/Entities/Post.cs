using SocialPlatformAPI.Domain.Entities.Common;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }
        public string? MediaUrl { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public ICollection<PostLike> Likes { get; set; } = new HashSet<PostLike>();
    }
}
