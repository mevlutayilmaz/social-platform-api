﻿using SocialPlatformAPI.Domain.Entities.Identity;

namespace SocialPlatformAPI.Domain.Entities
{
    public class Follow
    {
        public string FollowerId { get; set; }
        public string FollowingId { get; set; }
        public AppUser Follower { get; set; }
        public AppUser Following { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
