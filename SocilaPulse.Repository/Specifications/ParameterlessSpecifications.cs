using SocialPulse.Core.Interfaces.Specification;
using System.Linq.Expressions;

namespace SocialPulse.Repository.Specifications
{
    public class ParameterlessSpecifications<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get;}

        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();

        public Expression<Func<T, object>> OrderBy { get; protected set; }

        public Expression<Func<T, object>> OrderByDesc { get; protected set; }

        public int Take { get; protected set; }

        public int Skip { get; protected set; }

        public bool IsPaginated { get; protected set; }
        public void ApplyPagination(int pageSize, int pageIndex)
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }
    }
}
