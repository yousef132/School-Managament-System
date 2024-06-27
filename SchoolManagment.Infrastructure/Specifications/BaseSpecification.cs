using System.Linq.Expressions;

namespace SchoolManagment.Infrastructure.Specification
{
	public class BaseSpecification<T> : ISpecification<T>
	{
		public BaseSpecification(Expression<Func<T, bool>> criteria)
		{
			Criteria = criteria;
		}
		public Expression<Func<T, bool>> Criteria { get; set; }

		public List<Expression<Func<T, object>>> Includes { get; set; } = new();



		public void AddInclude(Expression<Func<T, object>> include)
		{
			Includes.Add(include);
		}
		public Expression<Func<T, object>> OrderBy { get; set; }
		public Expression<Func<T, object>> OrderByDescending { get; set; }


		public void AddOrderBy(Expression<Func<T, object>> orderBy)
			=> this.OrderBy = orderBy;

		public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
			=> this.OrderByDescending = orderByDescending;

		protected void ApplyPgination(int skip, int take)
		{
			Skip = skip;
			Take = take;
			IsPaginated = true;
		}
		public int Take { get; set; }
		public int Skip { get; set; }
		public bool IsPaginated { get; set; }
	}
}
