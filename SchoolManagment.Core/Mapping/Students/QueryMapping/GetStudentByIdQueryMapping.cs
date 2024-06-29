using SchoolManagment.Core.Features.Students.Queries.Responses;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void GetStudentByIdMapping()
		{
			CreateMap<Student, GetSingleStudentResponse>()
				.ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Localize(src.Department.NameAr, src.Department.NameEn)))
				.ForMember(dest => dest.Name, options => options.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
		}
	}
}
