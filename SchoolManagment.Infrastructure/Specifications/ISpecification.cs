using System.Linq.Expressions;

namespace SchoolManagment.Infrastructure.Specification
{
	public interface ISpecification<T>
	{
		Expression<Func<T, bool>> Criteria { get; set; }
		List<Expression<Func<T, object>>> Includes { get; set; }

		Expression<Func<T, object>> OrderBy { get; set; }
		Expression<Func<T, object>> OrderByDescending { get; set; }

		int Take { get; set; }
		int Skip { get; set; }

		bool IsPaginated { get; set; }
	}
}
