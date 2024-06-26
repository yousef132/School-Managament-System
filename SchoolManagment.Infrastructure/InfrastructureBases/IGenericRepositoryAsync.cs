using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolManagment.Infrastructure.InfrastructureBases
{
	public interface IGenericRepositoryAsync<T> where T : class
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
	}
}
