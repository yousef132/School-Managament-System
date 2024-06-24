using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Infrastructure.InfrastructureBases
{
	public interface IGenericRepositoryAsync<T> where T : class
	{

		void DeleteRange(ICollection<T> entities);
		void Delete(T entity);
		Task<T> GetByIdAsync(int id);
		Task SaveChangesAsync();


		IDbContextTransaction BeginTransaction();

		IQueryable<T> GetTableAsNotTracked();
		IQueryable<T> GetTableAsTracked();

		Task AddAsync(T entity);
		Task AddRangeAsync(ICollection<T> entities);
		void Update(T entity);

		void UpdateRange(ICollection<T> entities);
		void Commit();
		void RollBack();
	}
}
