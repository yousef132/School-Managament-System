using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Abstracts.Views
{
    public interface IViewRepository<T> : IGenericRepository<T> where T : class
    {

    }
}
