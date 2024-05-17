using SocialPulse.Core.DtoModels.CommentDto;
using SocialPulse.Core.Models;

namespace SocialPulse.Core.DtoModels.PostDto
{
    public class PostResultDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Content { get; set; }

        public string FilePath { get; set; }

        public DateTime CreatedDate { get; set; }
        public List<CommentResultDto> Comments { get; set; }
    }
}
