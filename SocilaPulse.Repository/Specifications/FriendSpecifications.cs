using SocialPulse.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Repository.Specifications
{
    public class FriendSpecifications : BaseSpecification<Friend>
    {
        public FriendSpecifications(Expression<Func<Friend, bool>> criteria) : base(criteria)
        {
        }
    }
}
