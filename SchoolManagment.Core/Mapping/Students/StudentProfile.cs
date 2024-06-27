using AutoMapper;
namespace SchoolManagment.Core.Mapping.Students
{
	public partial class StudentProfile : Profile
	{
		public StudentProfile()
		{
			GetStudentsMapping();
			GetStudentByIdMapping();
			AddStudentCommandMapping();
			EditStudentCommandMapping();
			GetStudentsWithPaginationMapping();
		}
	}
}