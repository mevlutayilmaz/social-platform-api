﻿namespace SocialPlatformAPI.Application.DTOs
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
