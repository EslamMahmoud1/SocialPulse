namespace SocialPulse.Core.DtoModels.CommentDto
{
    public class CommentResultDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
