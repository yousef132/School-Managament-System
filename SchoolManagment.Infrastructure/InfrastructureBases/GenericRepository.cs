using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Infrastructure.Specification;

namespace SchoolManagment.Infrastructure.InfrastructureBases
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        #region Vars / Props
        private readonly ApplicationDbContext context;

        #endregion

        #region Constructor
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        #endregion


        #region Methods
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
        }


        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction() => context.Database.BeginTransaction();

        public void Commit() => context.Database.CommitTransaction();
        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(ICollection<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);

        public IQueryable<T> GetTableAsTracked() => context.Set<T>().AsQueryable();

        public IQueryable<T> GetTableAsNotTracked() => context.Set<T>().AsNoTracking().AsQueryable();

        public void RollBack() => context.Database.RollbackTransaction();

        public async Task SaveChangesAsync() => await context.SaveChangesAsync();
        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await SaveChangesAsync();
        }
        public async Task UpdateRangeAsync(ICollection<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdWithSpecification(ISpecification<T> specs)
            => await ApplySpecs(specs)?.FirstOrDefaultAsync();


        private IQueryable<T> ApplySpecs(ISpecification<T> specs)
          => SpecificationEvaluater<T>.GetQuery(context.Set<T>(), specs);

        public async Task<List<T>> GetAllWithSpecification(ISpecification<T> specs)
            => await ApplySpecs(specs).ToListAsync();


        #endregion
    }
}
