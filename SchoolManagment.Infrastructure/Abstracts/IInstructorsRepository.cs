using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Abstracts
{
    public interface IInstructorsRepository : IGenericRepositoryAsync<Instructor>
    {
    }
}
