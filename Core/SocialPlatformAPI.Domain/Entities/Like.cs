using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Domain.Entities
{
    public class Like
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public AppUser User { get; set; }
    }
}
