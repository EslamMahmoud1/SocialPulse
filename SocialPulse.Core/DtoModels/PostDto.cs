﻿namespace SocialPulse.Core.DtoModels
{
    public class PostDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
