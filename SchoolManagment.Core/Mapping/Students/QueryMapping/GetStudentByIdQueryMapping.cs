using SchoolManagment.Core.Features.Students.Queries.Responses;
using SchoolManagment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagment.Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void GetStudentByIdMapping()
		{
			CreateMap<Student, GetSingleStudentResponse>()
				.ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name));
		}
	}
}
