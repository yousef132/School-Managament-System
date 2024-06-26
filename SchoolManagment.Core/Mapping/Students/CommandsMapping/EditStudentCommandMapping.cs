using AutoMapper;
using SchoolManagment.Core.Features.Students.Commands.Models;
using SchoolManagment.Data.Entities;

namespace SchoolManagment.Core.Mapping.Students
{
	public partial class StudentProfile : Profile
	{
		public void EditStudentCommandMapping()
		{
			CreateMap<EditStudentCommand, Student>()
				.ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DepartmentId))
				.ForMember(dest => dest.StudId, opt => opt.Ignore());
		}
	}
}
