using SocialPulse.Core.Models;
using SocialPulse.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Repository.Specifications
{
    public class UserSpecifications : BaseSpecification<User>
    {
        public UserSpecifications(string username) 
            : base(user => user.UserName == username)
        {
            IncludeExpressions.Add(x => x.Posts);
        }
    }
}
