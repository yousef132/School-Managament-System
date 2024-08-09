using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Abstracts
{
    public interface ISubjectRepository : IGenericRepositoryAsync<Subject>
    {
    }
}
