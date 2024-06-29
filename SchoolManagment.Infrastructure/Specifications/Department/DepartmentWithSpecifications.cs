
using SchoolManagment.Infrastructure.Specification;

namespace SchoolManagment.Infrastructure.Specifications.Department
{
	public class DepartmentWithSpecifications : BaseSpecification<SchoolManagment.Data.Entities.Department>
	{
		public DepartmentWithSpecifications(int id)
			: base(dept => dept.DeptId == id)
		{
			AddInclude(d => d.Instructors);
			AddInclude(d => d.DepartmentSubjects);
			AddInclude(d => d.Instructor);
			AddInclude(d => d.Students);
		}
	}
}
