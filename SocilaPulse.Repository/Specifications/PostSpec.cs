using SocialPulse.Core.Models;

namespace SocialPulse.Repository.Specifications
{
    public class PostSpec : BaseSpecification<Post>
    {
        public PostSpec(int id) : base(post => post.Id == id)
        {
            IncludeExpressions.Add(post => post.Comments);
        }
    }
}
