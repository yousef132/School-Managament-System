using SchoolManagment.Data.Entities;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Abstracts
{
	public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
	{
		//Task<Department> GetDepartmentById(int id);
	}
}
