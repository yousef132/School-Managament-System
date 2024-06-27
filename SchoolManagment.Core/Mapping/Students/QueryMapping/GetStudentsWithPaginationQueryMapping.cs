using SchoolManagment.Core.Features.Students.Queries.Models;
using SchoolManagment.Infrastructure.Specifications.Student;

namespace SchoolManagment.Core.Mapping.Students
{
	public partial class StudentProfile
	{

		public void GetStudentsWithPaginationMapping()
		{
			CreateMap<GetStudentsWithPaginationQuery, StudentSpecification>().ReverseMap();
		}
	}
}
