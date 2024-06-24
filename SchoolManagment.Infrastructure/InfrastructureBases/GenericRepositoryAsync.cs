using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagment.Infrastructure.Data;

namespace SchoolManagment.Infrastructure.InfrastructureBases
{
	public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
	{

		#region Vars / Props
		private readonly ApplicationDbContext context;

		#endregion

		#region Constructor
		public GenericRepositoryAsync(ApplicationDbContext context)
		{
			this.context = context;
		}
		#endregion


		#region Methods


		public async Task AddAsync(T entity)
			=> await context.Set<T>().AddAsync(entity);


		public async Task AddRangeAsync(ICollection<T> entities)
			=> await context.Set<T>().AddRangeAsync(entities);

		public IDbContextTransaction BeginTransaction() => context.Database.BeginTransaction();

		public void Commit() => context.Database.CommitTransaction();
		public void Delete(T entity) => context.Set<T>().Remove(entity);

		public void DeleteRange(ICollection<T> entities)
		=> context.RemoveRange(entities);


		public async Task<T> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);



		public IQueryable<T> GetTableAsTracked() => context.Set<T>().AsNoTracking().AsQueryable();

		public IQueryable<T> GetTableAsNotTracked() => context.Set<T>().AsNoTracking().AsQueryable();

		public void RollBack() => context.Database.RollbackTransaction();

		public Task SaveChangesAsync() => context.SaveChangesAsync();
		public void Update(T entity)
			=> context.Set<T>().Update(entity);
		public void UpdateRange(ICollection<T> entities)
			=> context.Set<T>().UpdateRange(entities);

		#endregion
	}
}
