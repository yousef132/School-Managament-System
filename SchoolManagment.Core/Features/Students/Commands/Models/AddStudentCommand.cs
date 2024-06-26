using MediatR;
using SchoolManagment.Core.Bases;

namespace SchoolManagment.Core.Features.Students.Commands.Models
{
	public class AddStudentCommand : IRequest<Response<string>>
	{
		public string Name { get; set; }

		public string Address { get; set; }
		public int DepartmentId { get; set; }

		public string Phone { get; set; }
	}
}
