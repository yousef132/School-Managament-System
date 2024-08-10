using SchoolManagment.Infrastructure.Data;
using System.Collections;

namespace SchoolManagment.Infrastructure.InfrastructureBases
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        //Task<int> CompleteAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;

        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            _repositories = new Hashtable();

        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            // if repository<order> => key = order
            var key = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(key))
            {
                var repo = new GenericRepository<TEntity>(context);

                _repositories.Add(key, repo);
            }

            return _repositories[key] as IGenericRepository<TEntity>;
        }
    }
}
