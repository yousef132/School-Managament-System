using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagment.Infrastructure.Specification;

namespace SchoolManagment.Infrastructure.InfrastructureBases
{
	public interface IGenericRepository<T> where T : class
	{

		Task DeleteRangeAsync(ICollection<T> entities);
		Task DeleteAsync(T entity);
		Task<T> GetByIdAsync(int id);
		Task SaveChangesAsync();


		IDbContextTransaction BeginTransaction();

		IQueryable<T> GetTableAsNotTracked();
		IQueryable<T> GetTableAsTracked();

		Task AddAsync(T entity);
		Task AddRangeAsync(ICollection<T> entities);
		Task UpdateAsync(T entity);

		Task UpdateRangeAsync(ICollection<T> entities);
		void Commit();
		void RollBack();


		public Task<T> GetByIdWithSpecification(ISpecification<T> specs);
		public Task<List<T>> GetAllWithSpecification(ISpecification<T> specs);
	}
}
