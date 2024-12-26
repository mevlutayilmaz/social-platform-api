﻿using SocialPlatformAPI.Domain.Entities.Common;
using SocialPlatformAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatformAPI.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}