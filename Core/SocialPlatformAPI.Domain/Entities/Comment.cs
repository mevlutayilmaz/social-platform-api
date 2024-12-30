using SocialPlatformAPI.Domain.Entities.Common;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public ICollection<CommentLike> Likes { get; set; } = new HashSet<CommentLike>();
    }
}
