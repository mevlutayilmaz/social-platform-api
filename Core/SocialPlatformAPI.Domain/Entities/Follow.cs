using SocialPlatformAPI.Domain.Entities.Common;
using SocialPlatformAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatformAPI.Domain.Entities
{
    public class Follow : BaseEntity
    {
        public string FollowerId { get; set; }
        public string FollowingId { get; set; }
        public AppUser Follower { get; set; }
        public AppUser Following { get; set; }
    }
}
