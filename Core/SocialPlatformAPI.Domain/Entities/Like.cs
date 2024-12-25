using SocialPlatformAPI.Domain.Entities.Common;
using SocialPlatformAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatformAPI.Domain.Entities
{
    public class Like : BaseEntity
    {
        public Guid PostId { get; set; }
        public string UserId { get; set; }
        public Post Post { get; set; }
        public AppUser User { get; set; }
    }
}
