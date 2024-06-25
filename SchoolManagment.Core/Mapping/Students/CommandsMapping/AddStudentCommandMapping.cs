using SchoolManagment.Core.Features.Students.Commands.Models;
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
		public void AddStudentCommandMapping()
		{
			CreateMap<AddStudentCommand, Student>()
				.ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DepartmentId));
		}
	}
}
