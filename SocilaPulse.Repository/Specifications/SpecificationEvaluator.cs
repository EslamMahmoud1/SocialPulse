using Microsoft.EntityFrameworkCore;
using SocialPulse.Core.Interfaces.Specification;
using SocialPulse.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPulse.Repository.Specifications
{
    public class SpecificationEvaluator<TEntity, TKey> where TEntity : class
    {
        public static IQueryable<TEntity> BuildQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)

                query = query.Where(specification.Criteria);

            if (specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);

            if (specification.OrderByDesc != null)
                query = query.OrderByDescending(specification.OrderByDesc);

            if (specification.IsPaginated == true)
                query = query.Skip(specification.Skip).Take(specification.Take);

            if (specification.IncludeExpressions.Any())
            {
                query = specification.IncludeExpressions
                  .Aggregate(query, (currentQuery, expression) => currentQuery.Include(expression));
            }

            return query;

        }
    }
}
