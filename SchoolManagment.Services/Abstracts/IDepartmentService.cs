using SchoolManagment.Data.Entities;

namespace SchoolManagment.Services.Abstracts
{
	public interface IDepartmentService
	{
		Task<Department> GetDepartmentById(int id);

	}
}
