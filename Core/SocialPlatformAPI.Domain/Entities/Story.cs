using SocialPlatformAPI.Domain.Entities.Common;
using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Domain.Entities
{
    public class Story : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
