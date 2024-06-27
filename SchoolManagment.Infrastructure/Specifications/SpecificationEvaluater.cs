using Microsoft.EntityFrameworkCore;

namespace SchoolManagment.Infrastructure.Specification
{
	public class SpecificationEvaluater<TEntity> where TEntity : class
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> baseQuery, ISpecification<TEntity> specs)
		{
			var query = baseQuery;

			if (specs?.Criteria != null)
				query = query.Where(specs.Criteria);

			if (specs?.OrderBy != null)
				query = query.OrderBy(specs.OrderBy);

			if (specs?.OrderByDescending != null)
				query = query.OrderByDescending(specs.OrderByDescending);

			if (specs.IsPaginated)
				query = query.Skip(specs.Skip).Take(specs.Take);

			query = specs.Includes.Aggregate(query,
				(currentQuery, includeExpression) => currentQuery.Include(includeExpression));

			return query;
		}
	}
}
