using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilterPageDemo
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> WhereMany<T>(this IQueryable<T> query, IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            if (predicates != null && predicates.Any())
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }

            return query;
        }
    }

}
