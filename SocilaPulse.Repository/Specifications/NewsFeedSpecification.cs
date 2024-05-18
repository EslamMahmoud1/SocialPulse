using SocialPulse.Core.Models;
using SocialPulse.Core.Specification;

namespace SocialPulse.Repository.Specifications
{
    public class NewsFeedSpecification : ParameterlessSpecifications<Post>
    {
        public NewsFeedSpecification(PostSpecificationParameters parameters)
        {
            if(parameters.Sort != null)
            {
                switch (parameters.Sort)
                {
                    case Sort.Asc:
                        OrderBy = x => x.CreatedDate;
                        break;
                    case Sort.Desc:
                        OrderByDesc = x => x.CreatedDate;
                        break;
                    default:
                        break;
                }
            }
            ApplyPagination(parameters.PageSize, parameters.PageIndex);
        }
    }
}
